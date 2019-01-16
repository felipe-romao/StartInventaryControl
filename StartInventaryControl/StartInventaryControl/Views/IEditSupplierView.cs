using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartInventaryControl.Views
{
    public interface IEditSupplierView
    {
        EditSupplierPresenter Presenter { set; }

        string SupplierName { get; set; }

        string ErrorMessage { set; }
        string InfoMessage { set; }

        void Dispose();
    }
}
