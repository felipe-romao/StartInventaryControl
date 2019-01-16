using System.Collections.Generic;

namespace StartInventaryControl.Views
{
    public interface IProductEntryView
    {
        ProductEntryPresenter Presenter { set; }
        IList<ProdutEntryDescriptor> ProductEntriesDescriptor { set; }
        string ErrorMessage { set; }
    }
}
