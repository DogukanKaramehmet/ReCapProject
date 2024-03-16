using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntitiyFramework
{
    public class EfBrandDal : IBrandDal
    {
        public void Add(Brand entitiy)
        {
            using (RentaCarContext context = new RentaCarContext())
            {
                var addedEntity= context.Entry(entitiy);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Brand entitiy)
        {
            using (RentaCarContext context = new RentaCarContext())
            {
                var updatedEntity = context.Entry(entitiy);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public Brand Get(Expression<Func<Brand, bool>> filtre)
        {
            using (RentaCarContext context = new RentaCarContext())
            {
                return context.Set<Brand>().SingleOrDefault(filtre);
            }
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filtre = null)
        {
            using (RentaCarContext context = new RentaCarContext())
            {
                return filtre==null
                    ? context.Set<Brand>().ToList() :
                    context.Set<Brand>().Where(filtre).ToList();
            }
        }

        public void Update(Brand entitiy)
        {
            using (RentaCarContext context = new RentaCarContext())
            {
                var deletedEntity = context.Entry(entitiy);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
