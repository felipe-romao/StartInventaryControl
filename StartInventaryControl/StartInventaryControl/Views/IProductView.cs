using StartInventaryControl.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartInventaryControl.Views
{
    public interface IProductView
    {
        ProductPresenter Presenter { set; }
        IList<Variation> Variations { set; }
        Product Product { get; }
        string ErrorMessage { set; }
        string InfoMessage { set; }
        string ChooseSalveXLSXFileToOpen();
    }
}
