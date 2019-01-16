using StartInventaryControl.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartInventaryControl.Views
{
    public interface IVariationTypeView
    {
        VariationTypePresenter Presenter { set; }
        IList<VariationType> VariationTypes { set; }
        VariationType VariationType { get; }
        string ErrorMessage { set; }
        string InfoMessage { set; }
    }
}
