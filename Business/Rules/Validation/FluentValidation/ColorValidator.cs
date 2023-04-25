using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using FluentValidation;

namespace Business.Rules.Validation.FluentValidation
{
    public class ColorValidator : AbstractValidator<Color>
    {

        public ColorValidator()
        {
            RuleFor(c => c.Name).MinimumLength(3);
        }
    }
}
