using StartInventaryControl.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartInventaryControl.Repository
{
    public interface IProductRepository
    {
        void Add(Product product);

        Product GetByID(long ID);

        IList<Product> GetAll();

        void Update(Product product);

        void Delete(Product product);
    }
}
