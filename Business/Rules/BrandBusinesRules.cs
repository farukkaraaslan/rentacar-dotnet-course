using Core.Utilities.Constants;
using Business.Rules.Validation.FluentValidation;
using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Exceptions;
using FluentValidation;

namespace Business.Rules
{
    //throw olan ve hata mesajı gönderen methodlar buraya yazılır.
    public class BrandBusinesRules
    {
        private readonly IBrandDal _brandDal;
        private readonly BrandValidator _validator;
        public BrandBusinesRules(IBrandDal brandDal,BrandValidator validator)
        {
            _brandDal = brandDal;
            _validator = validator;
        }

        public void ValidateBrand(Brand brand) 
        { 
            var result= _validator.Validate(brand);
            if (!result.IsValid)
            {
               var errorMessages =string.Join("\n", result.Errors.Select(e=>$"{e.PropertyName}: {e.ErrorMessage}"));
                throw new ValidationException(errorMessages);
            }
        }
       public void CheckIfExistBrandByName(string brandName)
        {
            if (_brandDal.Get(b => b.Name.ToLower() == brandName.ToLower()) != null)
            {
                throw new BusinessException(Messagess.Brand.AllReadyExists);
            }
        }

        public void CheckIfBrandExist(int id)
        {
            if (_brandDal.Get(b => b.Id == id) == null)
            {
                throw new BusinessException(Messagess.Brand.NotExists);
            }
        }


    }
}
