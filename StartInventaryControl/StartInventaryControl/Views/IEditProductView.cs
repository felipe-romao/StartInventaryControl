using StartInventaryControl.Data;
using System.Collections.Generic;

namespace StartInventaryControl.Views
{
    public interface IEditProductView
    {
        EditProductPresenter Presenter { set; }

        string Description { get; set; }

        string ImagePath { get; set; }

        string Annotation { get; set; }

        IList<Variation> Variations { get; set; }

        string ErrorMessage { set; }
        string InfoMessage { set; }

        bool HasUnsavedChanges { get; set; }

        string ChooseLogFileToOpen();
    }
}
