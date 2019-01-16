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
using Microsoft.Win32;

namespace StartInventaryControl.Views.WPF
{
    /// <summary>
    /// Interaction logic for ProductWindow.xaml
    /// </summary>
    public partial class ProductWindow : Window, IProductView
    {
        public ProductWindow()
        {
            InitializeComponent();
            this.addProductButton.Click     += (sender, args) => this.Presenter.OnAddedProduct();
            this.updateProductButton.Click  += (sender, args) => this.Presenter.OnUpdatedProduct();
            this.ExportProductsButton.Click += (sender, args) => this.Presenter.OnExportedAllProducts();
        }

        public ProductPresenter Presenter
        {
            set;
            private get;
        }

        public Product Product
        {
            get
            {
                var variation = this.productGrid.SelectedItem as Variation;
                return variation.Product;
            }
        }

        public IList<Variation> Variations
        {
            set
            {
                this.productGrid.ItemsSource = value;
            }
        }

        public string InfoMessage
        {
            set
            {
                MessageBox.Show(value, "Start", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        public string ErrorMessage
        {
            set
            {
                MessageBox.Show(value, "Start", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public string ChooseSalveXLSXFileToOpen()
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Pasta de trabalho do Excel (*.xlsx)|*.xlsx";
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            saveFileDialog.OverwritePrompt = true;

            var ok = saveFileDialog.ShowDialog().GetValueOrDefault(false);
            return ok ? saveFileDialog.FileName : null;
        }
    }
}
