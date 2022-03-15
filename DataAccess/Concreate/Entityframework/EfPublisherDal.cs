using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concreate.Entityframework.Contexts;
using Entities.Concreate;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concreate.Entityframework
{
    public class EfPublisherDal:EfEntityRepositoryBase<Publisher,MiaTeknoloji>,IPublisherDal
    {
        public IList<Publisher> GetFilter(List<string> filter, int? page = null, int? count = null)
        {
            var predicate = PredicateBuilder.False<Publisher>();
            using (var context = new MiaTeknoloji())
            {
                var a = context.Set<Publisher>();
                foreach (var item in filter)
                {
                    predicate = predicate.Or(f => f.Title.Contains(item));
                    predicate = predicate.Or(f => f.Summary.Contains(item));
                }
                return context.Set<Publisher>().Where(predicate).Skip((int)page * (int)count).Take((int)count).ToList();
            }
        }
    }
}
