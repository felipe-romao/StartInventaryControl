using StartInventaryControl.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartInventaryControl.Repository
{
    public interface IModelRepository
    {
        void Add(Model model);

        IList<Model> GetAll();

        void Update(Model model);

        void Delete(Model model);
    }
}
