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
    public class EfColorDal : IColorDal
    {
        public void Add(Color entitiy)
        {
            using (RentaCarContext context = new RentaCarContext())
            {
                var addedEntitiy = context.Entry(entitiy);
                addedEntitiy.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Color entitiy)
        {
            using (RentaCarContext context = new RentaCarContext())
            {
                var deletedEntitiy = context.Entry(entitiy);
                deletedEntitiy.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Color Get(Expression<Func<Color, bool>> filtre)
        {
            using (RentaCarContext context = new RentaCarContext())
            {
                return context.Set<Color>().SingleOrDefault(filtre);
            }
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filtre = null)
        {
            using (RentaCarContext context = new RentaCarContext())
            {
                return filtre == null 
                    ? context.Set<Color>().ToList()
                    : context.Set<Color>().Where(filtre).ToList();
            }
        }

        public void Update(Color entitiy)
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
