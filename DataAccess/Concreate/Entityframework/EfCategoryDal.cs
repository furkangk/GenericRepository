using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concreate.Entityframework.Contexts;
using Entities.Concreate;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq;
namespace DataAccess.Concreate.Entityframework
{
    public class EfCategoryDal:EfEntityRepositoryBase<Category,MiaTeknoloji>,ICategoryDal
    {
        public IList<Category> GetFilter(List<string> filter, int? page = null, int? count = null)
        {
            var predicate = PredicateBuilder.False<Category>();
            using (var context = new MiaTeknoloji())
            {
                var a = context.Set<Category>();
                foreach (var item in filter)
                {
                    predicate = predicate.Or(f => f.Title.Contains(item));

                }
                return context.Set<Category>().Where(predicate).Skip((int)page * (int)count).Take((int)count).ToList();
            }
        }
    }
}
