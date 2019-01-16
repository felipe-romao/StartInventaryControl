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

namespace StartInventaryControl.Views.WPF
{
    /// <summary>
    /// Interaction logic for ProdutEntryWindow.xaml
    /// </summary>
    public partial class ProdutEntryWindow : Window, IProductEntryView
    {
        public ProdutEntryWindow()
        {
            InitializeComponent();
            this.addProductEntryButton.Click += (sender, args) => this.Presenter.OnAddedNewProductEntry();
        }

        public ProductEntryPresenter Presenter
        {
            private get;
            set;
        }

        public IList<ProdutEntryDescriptor> ProductEntriesDescriptor
        {
            set
            {
                this.productEntriesGrid.ItemsSource = value;
                this.productEntriesGrid.Items.Refresh();
            }
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
