using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class CarDal : ICarDal
    {
        List<Car> _cars;
        public CarDal()
        {
            _cars = new List<Car>
            {
                new Car { Id = 1, BrandId = 1,DailyPrice=700000,ModelYear=2013,Description="Açıklama" },
                new Car { Id = 2, BrandId = 1,DailyPrice=900000,ModelYear=2018,Description="Açıklama" },
                new Car { Id = 3, BrandId = 2,DailyPrice=300000,ModelYear=2000,Description="Açıklama" },
                new Car { Id = 4, BrandId = 2,DailyPrice=400000,ModelYear=2006,Description="Açıklama" },
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(p => p.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int BrandId)
        {
            return _cars.Where(p => p.BrandId == BrandId).ToList();
        }

        public void Update(Car car)
        {
            Car carUpdate = _cars.SingleOrDefault(p => p.Id == car.Id);
            carUpdate.ModelYear = car.ModelYear;
            carUpdate.Description = car.Description;
            carUpdate.DailyPrice = car.DailyPrice;
            carUpdate.BrandId = car.BrandId;
        }
    }
}
