using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concreate.Entityframework.Contexts;
using Entities.Concreate;
using LinqKit;

namespace DataAccess.Concreate.Entityframework
{
    public class EfBookDal : EfEntityRepositoryBase<Book, MiaTeknoloji>, IBookDal
    {
        public IList<Book> GetFilter(List<string> filter, int? page = null, int? count = null)
        {
            var predicate = PredicateBuilder.False<Book>();
            using (var context = new MiaTeknoloji())
            {
                var a = context.Set<Book>();
                foreach (var item in filter)
                {
                    predicate = predicate.Or(f => f.Title.Contains(item));

                }
                return context.Set<Book>().Where(predicate).Skip((int)page * (int)count).Take((int)count).ToList();
            }
        }
    }
}
