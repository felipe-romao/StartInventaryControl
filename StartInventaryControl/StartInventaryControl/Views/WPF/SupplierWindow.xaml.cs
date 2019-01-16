using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using StartInventaryControl.Data;

namespace StartInventaryControl.Views.WPF
{
    /// <summary>
    /// Interaction logic for SupplierWindow.xaml
    /// </summary>
    public partial class SupplierWindow : Window, ISupplierView
    {
        public SupplierWindow()
        {
            InitializeComponent();

            this.addProductButton.Click += (sender, args)    => this.Presenter.OnAddedSupplier();
            this.updateProductButton.Click += (sender, args) => this.Presenter.OnUpdatedSupplier();
        }

        public SupplierPresenter Presenter
        {
            set; private get;
        }

        public string ErrorMessage
        {
            set
            {
                MessageBox.Show(value, "Start", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public string InfoMessage
        {
            set
            {
                MessageBox.Show(value, "Start", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        public Supplier Supplier
        {
            get
            {
                return this.supplierGrid.SelectedItem as Supplier;
            }
        }

        public IList<Supplier> Suppliers
        {
            set
            {
                this.supplierGrid.ItemsSource = value;
            }
        }
    }
}
