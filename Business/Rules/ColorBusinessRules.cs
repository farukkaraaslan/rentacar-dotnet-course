using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Constants;
using Business.Rules.Validation.FluentValidation;
using Core.Exceptions;
using DataAccess.Abstract;
using static Business.Constants.Messagess;
using Color = Entities.Color;

namespace Business.Rules
{
    public class ColorBusinessRules
    {
        private readonly IColorDal _colorDal;
        private readonly ColorValidator _validator;

        public ColorBusinessRules(IColorDal colorDal, ColorValidator validator)
        {
            _colorDal = colorDal;
            _validator = validator;

        }

        public void ValidateColor(Color color)
        {
            var result = _validator.Validate(color);
            if (!result.IsValid)
            {
                var errorMessages = string.Join("\n", result.Errors.Select(e => $"{e.PropertyName}: {e.ErrorMessage}"));
                throw new Exception(errorMessages);
            }
        }

        public void CheckIfExistColorByName(string colorName)
        {
            if (_colorDal.Get(c => c.Name.ToLower() == colorName.ToLower()) != null)
            {
                throw new BusinessException(Messagess.Color.AllReadyExists);
            }

        }
        public void CheckIfColorExist(int id)
        {
            if (_colorDal.Get(c => c.Id == id) == null)
            {
                throw new BusinessException(Messagess.Color.NotExists);
            }
        }
    }
}
