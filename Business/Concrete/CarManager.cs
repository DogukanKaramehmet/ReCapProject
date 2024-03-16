using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntitiyFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        EfCarDal _efCarDal;

        public CarManager(EfCarDal carDal)
        {
            _efCarDal = carDal;
        }

        public void Add(Car car)
        {
            if (car.CarName.Length > 2)
            {
                _efCarDal.Add(car);
            }
            else
            {
                Console.WriteLine("Hatalı işlem");
            }
        }
        public void Delete(Car car)
        {
            _efCarDal.Delete(car);
        }

        public List<Car> Get(int id)
        {
            return _efCarDal.GetAll(p => p.Id == id);
        }

        public List<Car> GetAll()
        {
            return _efCarDal.GetAll();
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _efCarDal.GetAll(p=>p.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _efCarDal.GetAll(p => p.ColorId == id);
        }

        public void Update(Car car)
        {
            _efCarDal.Update(car);
        }
    }
}
