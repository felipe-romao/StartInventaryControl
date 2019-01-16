using StartInventaryControl.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartInventaryControl.Views
{
    public interface IEditProductIssueView
    {
        EditProductIssuePresenter Presenter { set; }

        IList<Product> Products { set; }
        Product Product { get; set; }

        string Annotation { get; set; }

        string imagePath { set; }

        DateTime Date { get; set; }

        IList<ProductIssueItemDescriptor> ProductIssueItems { get; set; }

        IList<string> Genders { set; }
        IList<string> Colors { set; }
        IList<string> Sizes { set; }

        string SelectedGender { get; set; }
        string SelectedColor { get; set; }
        IDictionary<string, int> QuantityBySize { get; }

        string ErrorMessage { set; }
        string InfoMessage { set; }

        void InsertProductIssueItem(IList<ProductIssueItemDescriptor> items);

        void RemoveProductIssueItem(int index);

        int SelectedProductIssueItemIndex { get; }

        bool HasUnsavedChanges { get; set; }
        bool HasUnsavedProductChanges { get; set; }
    }
}
