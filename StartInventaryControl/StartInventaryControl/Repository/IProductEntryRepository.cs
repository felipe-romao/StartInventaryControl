using StartInventaryControl.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartInventaryControl.Repository
{
    public interface IProductEntryRepository
    {
        void Add(ProductEntry productEntry);

        ProductEntry GetByCode(string code);

        IList<ProductEntry> GetAll();

        void Update(ProductEntry productEntry);

        void Delete(ProductEntry productEntry);
    }
}
