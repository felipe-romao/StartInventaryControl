using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartInventaryControl.Views
{
    public interface IEditVariationTypeView
    {
        EditVariationTypePresenter Presenter { set; }

        IList<string> VariationTypes { set; }

        string VariationType { get; }
        string VariationValue { get; set; }

        string ErrorMessage { set; }
        string InfoMessage { set; }

        void Dispose();
    }
}
