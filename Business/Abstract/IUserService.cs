using Core.Entities.ConCreate;
using Core.Utilities.Results;
using Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public  interface IUserService
    {
        void Add(User user);
        IResult Update(User user);
        IResult Delete(User user);
        User GetByMail(string email);
        IDataResult<User> GetById(int userId);
        IDataResult<User> GetOne(int userId);
        List<OperationClaim> GetOperationClaims(User user);

    }
}
