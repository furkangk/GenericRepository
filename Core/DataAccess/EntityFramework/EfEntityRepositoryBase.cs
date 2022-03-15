using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity> 
        where TEntity : class, IEntity, new() 
        where TContext : DbContext, new()
    {
        public int Add(TEntity entity)
        {
            using (var context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
                var IdProperty = entity.GetType().GetProperty("Id").GetValue(entity, null);
                return (int)IdProperty;
            }
        }

        public void Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public IList<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null,int? page = null, int? count=null)
        {
            using (var context = new TContext())
            {
                if (filter == null && page==null && count == null)
                {
                    return context.Set<TEntity>().ToList();
                }
                else if (filter==null & count==null && page !=null)
                {
                    return context.Set<TEntity>().Skip((int)page*10).Take(10).ToList();
                }
                else if (filter == null & page != null && count !=null)
                {
                    return context.Set<TEntity>().Skip((int)page*(int)count).Take((int)count).ToList();
                }
                else if (filter !=null & page != null && count != null)
                {
                    return context.Set<TEntity>().Where(filter).Skip((int)page * (int)count).Take((int)count).ToList();
                }
                else if (filter != null & page != null && count == null)
                {
                    return context.Set<TEntity>().Where(filter).Skip((int)page * 10).Take(10).ToList();
                }
                else
                {
                    return context.Set<TEntity>().Where(filter).ToList();
                }
            }
        }

        public int GetCount(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                return filter==null
                    ?context.Set<TEntity>().ToList().Count()
                    :context.Set<TEntity>().Where(filter).ToList().Count();

            }
        }
        public void Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                var updateEntity = context.Entry(entity);
                updateEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
