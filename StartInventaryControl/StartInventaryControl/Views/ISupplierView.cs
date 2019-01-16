using StartInventaryControl.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartInventaryControl.Views
{
    public interface ISupplierView
    {
        SupplierPresenter Presenter { set; }
        IList<Supplier> Suppliers { set; }
        Supplier Supplier { get; }
        string ErrorMessage { set; }
        string InfoMessage { set; }
    }
}
