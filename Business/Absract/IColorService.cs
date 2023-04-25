using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Absract
{
    public interface IColorService
    {
        List<Color> GetAll();
        Color GetById(int id);
        Color GetByName(string name);
        void Add(Color color);
        void Update(Color color);
        void Delete(int id);
    }
}
