using Core.DataAccess.EntityFramework;
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
    public class EfBookImageDal : EfEntityRepositoryBase<BookImage,MiaTeknoloji>, IBookImageDal
    {
    }
}
