using Core.Utilities.Results;
using Business.Abstract;
using Business.Contants;
using Core.Entities.ConCreate;
using Core.Utilities.Hashing;
using Core.Utilities.Security.jwt;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate
{
    public class AuthManager : IAuthService
    {
         private IUserService _userService;
         private ITokenHelper _tokenHelper;

         public AuthManager(IUserService userService,ITokenHelper tokenHelper)
         {
             _userService = userService;
             _tokenHelper = tokenHelper;
         }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetOperationClaims(user);
            var accestoken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accestoken, Messages.AccesTokenCreated);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null || userToCheck.Status==false)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }
            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }
            return new SuccessDataResult<User>(userToCheck, Messages.SuccessfulLogin);
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                Name = userForRegisterDto.Name,
                Surname = userForRegisterDto.Surname,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true,
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user, Messages.UserRegistered);
        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByMail(email) != null) 
            {
                return new ErrorResult(Messages.UserAlreadyExits);
            }
            return new SuccessResult();
        }
    }
}
