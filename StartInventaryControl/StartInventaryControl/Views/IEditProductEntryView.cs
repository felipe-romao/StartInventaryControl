using StartInventaryControl.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartInventaryControl.Views
{
    public interface IEditProductEntryView
    {
        EditProductEntryPresenter Presenter { set; }

        IList<Supplier> Suppliers { set; }
        Supplier Supplier { get; set; }

        IList<Product> Products { set; }
        Product Product { get; set; }

        string Annotation { get; set; }

        string imagePath { set; }

        DateTime Date { get; set; }

        IList<ProdutEntryItemDescriptor> ProductEntryItems { get; set; }

        IList<string> Genders { set; }
        IList<string> Colors { set; }
        IList<string> Sizes { set; }

        string SelectedGender { get; set; }
        string SelectedColor { get; set; }
        IDictionary<string, int> QuantityBySize { get; }

        string ErrorMessage { set; }
        string InfoMessage { set; }

        void InsertProductEntryItem(IList<ProdutEntryItemDescriptor> items);

        void RemoveProductEntryItem(int index);

        int SelectedProductEntryItemIndex { get; }

        bool HasUnsavedChanges { get; set; }
        bool HasUnsavedProductChanges { get; set; }
    }
}
