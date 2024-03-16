using DataAccess.Abstract;
using Entities.Abstract;
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
    public class EfCarDal : ICarDal
    {
        public void Add(Car entitiy)
        {
            using (RentaCarContext context = new RentaCarContext())
            {
                var addedEntitiy = context.Entry(entitiy);
                addedEntitiy.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Car entitiy)
        {
            using (RentaCarContext context = new RentaCarContext())
            {
                var deletedEntitiy = context.Entry(entitiy);
                deletedEntitiy.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filtre)
        {
            using (RentaCarContext context = new RentaCarContext())
            {
                return context.Set<Car>().SingleOrDefault(filtre);
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filtre = null)
        {
            using (RentaCarContext context = new RentaCarContext())
            {
                return filtre == null ?
                    context.Set<Car>().ToList()
                    : context.Set<Car>().Where(filtre).ToList();
            }
        }

        public void Update(Car entitiy)
        {
            using (RentaCarContext context = new RentaCarContext())
            {
                var updatedEntitiy = context.Entry(entitiy);
                updatedEntitiy.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
