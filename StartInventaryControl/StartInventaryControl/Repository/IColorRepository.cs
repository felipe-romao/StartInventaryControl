using StartInventaryControl.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartInventaryControl.Repository
{
    public interface IColorRepository
    {
        void Add(Color color);

        IList<Color> GetAll();

        void Update(Color color);

        void Delete(Color color);
    }
}
