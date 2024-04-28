using DataAccess.Abstract;
using Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntitiyFramework
{
    public class EfEntitiyRepositoryBase<TEntitiy, TContext> : IEntityRepository<TEntitiy>
        where TEntitiy : class, IEntitiy, new()
        where TContext : DbContext, new()

    {
        public void Add(TEntitiy entitiy)
        {
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entitiy);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEntitiy entitiy)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entitiy);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntitiy Get(Expression<Func<TEntitiy, bool>> filtre)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntitiy>().SingleOrDefault(filtre);
            }
        }

        public List<TEntitiy> GetAll(Expression<Func<TEntitiy, bool>> filtre = null)
        {
            using (TContext context = new TContext())
            {
                return filtre == null
                    ? context.Set<TEntitiy>().ToList() :
                    context.Set<TEntitiy>().Where(filtre).ToList();
            }
        }

        public void Update(TEntitiy entitiy)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entitiy);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();

                
            }
        }
    }
}
