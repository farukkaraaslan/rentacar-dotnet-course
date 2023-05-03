using Business.Abstract;
using Business.Rules;
using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        private readonly IBrandDal _brandDal;
        private readonly BrandBusinesRules _rules;

        public BrandManager(IBrandDal brandDal, BrandBusinesRules rules)
        {
            _brandDal = brandDal;
            _rules = rules;
        }

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }

        public Brand GetById(int id)
        {
            _rules.CheckIfBrandExist(id);
            return _brandDal.Get(b => b.Id == id);
        }
        public Brand GetByName(string name)
        {
            return _brandDal.Get(b => b.Name.ToLower() == name.ToLower());
        }
        public void Add(Brand brand)
        {
            _rules.ValidateBrand(brand);
            _rules.CheckIfExistBrandByName(brand.Name);
            CapitalizeBrandName(brand);

           _brandDal.Add(brand);
        }

        public void Delete(int id)
        {
            _rules.CheckIfBrandExist(id);
            _brandDal.Delete(id);
        }
      
        public void Update(Brand brand)
        {
            _rules.ValidateBrand(brand);
            _rules.CheckIfBrandExist(brand.Id);
            CapitalizeBrandName(brand);
            _brandDal.Update(brand);
        }

        private void CapitalizeBrandName(Brand brand)
        {
            TextInfo textInfo = new CultureInfo("tr-TR", false).TextInfo;
            brand.Name = textInfo.ToTitleCase(brand.Name);
        }
    }
}
