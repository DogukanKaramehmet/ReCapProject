using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidation : AbstractValidator<Car>
    {
        public CarValidation()
        {
            RuleFor(p => p.CarName).NotEmpty();
            RuleFor(p => p.BrandId).NotEmpty(); 
            RuleFor(p => p.ColorId).NotEmpty();
            RuleFor(p => p.DailyPrice).NotEmpty();
            RuleFor(p => p.ModelYear).NotEmpty();
            RuleFor(p => p.Description).NotEmpty();
            RuleFor(p => p.CarName).MinimumLength(5);
        }
    }
}
