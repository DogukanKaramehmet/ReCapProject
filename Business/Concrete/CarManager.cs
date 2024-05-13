using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validaiton;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntitiyFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [ValidationAspect(typeof(CarValidation))]
        public IResult Add(Car car)
        {
            //business kuralları buraya yazılıyor 
            BusinessRules.Run(CheckIfCarCountMaximum(car.CarId)); //busines rules diye class açtık ve kural motoru yaptık
            _carDal.Add(car);

            return new SuccessResult(Messages.CarAdded);

        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<Car> Get(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(p => p.CarId == id));

        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailDtos()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailDtos());
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == id));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == id));
        }

        [ValidationAspect(typeof(CarValidation))]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        public  IResult CheckIfCarCountMaximum(int carId)
        {
            var result = _carDal.GetAll(p => p.CarId == carId).Count();
            if (result <= 10)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }
    }
}
