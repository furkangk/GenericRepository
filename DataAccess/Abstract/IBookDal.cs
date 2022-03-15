﻿using Core.DataAccess;
using Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IBookDal : IEntityRepository<Book>
    {
        IList<Book> GetFilter(List<string> filter, int? page = null, int? count = null);
    }
}
