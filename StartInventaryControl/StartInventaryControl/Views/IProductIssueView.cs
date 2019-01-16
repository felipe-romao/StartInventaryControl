using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartInventaryControl.Views
{
    public interface IProductIssueView
    {
        ProductIssuePresenter Presenter { set; }
        IList<ProdutIssueDescriptor> ProductIssuesDescriptor { set; }
        string ErrorMessage { set; }
    }
}
