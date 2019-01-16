using StartInventaryControl.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartInventaryControl.Repository
{
    public interface IProductIssueRepository
    {
        void Add(ProductIssue productIssue);

        ProductIssue GetByCode(string code);

        IList<ProductIssue> GetAll();

        void Update(ProductIssue productIssue);

        void Delete(ProductIssue productIssue);
    }
}
