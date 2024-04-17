using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _ColorDal;

        public ColorManager(IColorDal colorDal)
        {
            _ColorDal = colorDal;
        }

        public void Add(Color color)
        {
            _ColorDal.Add(color);
        }

        public void Delete(Color color)
        {
            _ColorDal.Delete(color);
        }

        public Color Get(int id)
        {
            return _ColorDal.Get(c => c.ColorId == id);
        }

        public List<Color> GetAll()
        {
            return _ColorDal.GetAll();
        }

        public void Update(Color color)
        {
            _ColorDal.Update(color);
        }
    }
}
