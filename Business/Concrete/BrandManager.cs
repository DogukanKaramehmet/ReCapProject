using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validaiton;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _BrandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _BrandDal = brandDal;
        }
        [ValidationAspect(typeof(BrandValidation))]
        public IResult Add(Brand brand)
        {
            _BrandDal.Add(brand);
            return new SuccessResult(Messages.BrandAdded);
        }

        public IResult Delete(Brand brand)
        {
            _BrandDal.Delete(brand);
            return new SuccessResult(Messages.BrandDeleted);

        }

        public IDataResult< List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>( _BrandDal.GetAll());
        }

        public IDataResult< Brand> GetById(int id)
        {
            return new SuccessDataResult<Brand>( _BrandDal.Get(b => b.BrandId == id));
        }
        [ValidationAspect(typeof(BrandValidation))]
        public IResult Update(Brand brand)
        {
            _BrandDal.Update(brand);
            return new SuccessResult(Messages.BrandUpdated);
        }
    }
}
