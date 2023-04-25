using Business.Absract;
using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Rules;
using System.Globalization;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        private readonly IColorDal _colorDal;
        private readonly ColorBusinessRules _rules;

        public ColorManager(IColorDal colorDal,ColorBusinessRules rules)
        {
            _colorDal = colorDal;
            _rules = rules;
        }

        public void Add(Color color)
        {
            _rules.ValidateColor(color);
            _rules.CheckIfExistColorByName(color.Name);
            CapitalizeColorName(color);
            _colorDal.Add(color);
        }

        public void Delete(int id)
        {
            _rules.CheckIfColorExist(id);
          _colorDal.Delete(id);
        }

        public List<Color> GetAll()
        {
            return _colorDal.GetAll();
        }

        public Color GetById(int id)
        {
            _rules.CheckIfColorExist(id);
            return _colorDal.Get(c => c.Id == id);
        }

        public Color GetByName(string name)
        {
            return _colorDal.Get(c =>c.Name.ToLower() == name.ToLower());
        }

        public void Update(Color color)
        {
            _rules.CheckIfColorExist(color.Id);
            CapitalizeColorName(color);
            _colorDal.Update(color);
        }

        private void CapitalizeColorName(Color color)
        {
            TextInfo textInfo = new CultureInfo("tr-TR", false).TextInfo;
            color.Name = textInfo.ToTitleCase(color.Name);
        }
    }
}
