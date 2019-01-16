using StartInventaryControl.Views;
using System.Windows;

namespace StartInventaryControl
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IMainView
    {
        public MainWindow(ApplicationController controller)
        {
            InitializeComponent();

            this.Presenter = new MainPresenter(this, controller);

            this.productEntryMenuItem.Click      += (sender, args) => this.Presenter.OnProductEntry();
            this.editProductEntryMenuItem.Click  += (sender, args) => this.Presenter.OnEditProductEntry();
            this.productIssueMenuItem.Click      += (sender, args) => this.Presenter.OnProductIssue();
            this.editProductIssueMenuItem.Click  += (sender, args) => this.Presenter.OnEditProductIssue();
            this.productsMenuItem.Click          += (sender, args) => this.Presenter.OnProduct();
            this.editProductMenuItem.Click       += (sender, args) => this.Presenter.OnEditProduct();
            this.suppliersMenuItem.Click         += (sender, args) => this.Presenter.OnSupplier();
            this.editSupplierMenuItem.Click      += (sender, args) => this.Presenter.OnEditSupplier();
            this.variationTypesMenuItem.Click    += (sender, args) => this.Presenter.OnVariationType();
            this.editVariationTypeMenuItem.Click += (sender, args) => this.Presenter.OnEditVariationType();
        }

        public MainPresenter Presenter
        {
            private get;
            set;
        }

        public string ErrorMessage
        {
            set
            {
                MessageBox.Show(value, "Start", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
