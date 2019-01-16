using StartInventaryControl.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartInventaryControl.Repository
{
    public interface IVariationTypeRepository
    {
        void Add(VariationType variationType);
        IList<VariationType> GetAll();
        void Delete(VariationType variationType);
    }
}
