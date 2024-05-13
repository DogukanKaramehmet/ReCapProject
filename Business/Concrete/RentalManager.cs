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
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        //***************************************

        [ValidationAspect(typeof(RentalValidation))]
        public IResult Add(Rental rental)
        {
            bool isCarAvailable = !(_rentalDal.GetAll(r => r.CarId == rental.CarId && r.ReturnDate == rental.ReturnDate).Any());
            if (isCarAvailable== false)
            {
                return new ErrorResult(Messages.RentalCancel);
            }
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAccep);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDelete);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        [ValidationAspect(typeof(RentalValidation))]
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdate);
        }
    }
}
