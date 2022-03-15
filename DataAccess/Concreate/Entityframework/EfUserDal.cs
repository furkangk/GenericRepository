using Core.DataAccess.EntityFramework;
using Core.Entities.ConCreate;
using DataAccess.Abstract;
using DataAccess.Concreate.Entityframework.Contexts;
using Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concreate.Entityframework
{
    public class EfUserDal : EfEntityRepositoryBase<User, MiaTeknoloji>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
           using(var context=new MiaTeknoloji())
            {
                var result = from operationClaim in context.OperationClaim
                             join userOprerationClaim in context.UserOperationClaim
                             on operationClaim.Id equals userOprerationClaim.OperationClaimId
                             where userOprerationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();
            }
        }
        public User GetOne(int userid)
        {
            using (var context=new MiaTeknoloji())
            {
                var result = from User in context.User
                             where User.Id == userid
                             select new User
                             { Id = User.Id, Address = User.Address, Email = User.Email, Image = 
                             User.Image, Name = User.Name, Surname = User.Surname, Phone = User.Phone, Tckn = User.Tckn } ;
                return result.First();
            }
        }
    }
}
