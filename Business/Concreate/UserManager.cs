using Business.Abstract;
using Business.Contants;
using Core.Entities.ConCreate;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void Add(User user)
        {
            _userDal.Add(user);
        }
        public IResult Update(User user)
        {
            var GetUser = GetById(user.Id);
            user.PasswordHash = GetUser.Data.PasswordHash;
            user.PasswordSalt = GetUser.Data.PasswordSalt;
            user.Status = GetUser.Data.Status;
            user.Email = GetUser.Data.Email;
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdateMessage);
        }

        public IResult Delete(User user)
        {
            var GetUser = GetById(user.Id);
            user = GetUser.Data;
            user.Status = false;
            _userDal.Update(user);
            return new SuccessResult(Messages.UserDeleteMessage);
        }

        public IDataResult<User> GetById(int userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == userId));
        }
        public IDataResult<User> GetOne(int userId)
        {
            return new SuccessDataResult<User>(_userDal.GetOne(userId));
        }
        public User GetByMail(string Email)
        {
            return _userDal.Get(u => u.Email == Email);
        }

        public List<OperationClaim> GetOperationClaims(User user)
        {
            return _userDal.GetClaims(user);
        }
    }
}
