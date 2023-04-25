using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;
using Entities;
using FluentValidation;

namespace Business.Rules.Validation.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c=> c.Plate).NotEmpty();
            RuleFor(c=>c.Description).MinimumLength(10).NotEmpty();
            RuleFor(c => c.DailyPrice).NotEmpty();
            RuleFor(c => c.ModelYear).GreaterThan(1999);
            RuleFor(c => c.ModelYear).LessThan(DateTime.Now.Year + 1);

        }   
    }
}
