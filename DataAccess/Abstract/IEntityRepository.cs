using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IEntityRepository<T>where T : class,IEntitiy,new()
    {
        List<T> GetAll(Expression<Func<T,bool>>filtre = null);
        T Get(Expression<Func<T, bool>> filtre);
        void Add(T entitiy);
        void Delete(T entitiy);
        void Update(T entitiy);
    }
}
