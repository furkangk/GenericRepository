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
    public class EfLocationDal : EfEntityRepositoryBase<Location, MiaTeknoloji>, ILocationDal
    {
        public IList<Location> GetFilter(List<string> filter, int? page = null, int? count = null)
        {
            var predicate = PredicateBuilder.False<Location>();
            using (var context = new MiaTeknoloji())
            {
                var a = context.Set<Location>();
                foreach (var item in filter)
                {
                    predicate = predicate.Or(f => f.Title.Contains(item));
                    predicate = predicate.Or(f => f.Shelf.Contains(item));
                    predicate = predicate.Or(f => f.Floor.Contains(item));
                    predicate = predicate.Or(f => f.Block.Contains(item));

                }
                return context.Set<Location>().Where(predicate).Skip((int)page * (int)count).Take((int)count).ToList();
            }
        }
    }
}
