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
    /// Interaction logic for ProductIssueWindow.xaml
    /// </summary>
    public partial class ProductIssueWindow : Window, IProductIssueView
    {
        public ProductIssueWindow()
        {
            InitializeComponent();
            this.addProductIssueButton.Click += (sender, args) => this.Presenter.OnAddedNewProductIssue();
        }

        public ProductIssuePresenter Presenter
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

        public IList<ProdutIssueDescriptor> ProductIssuesDescriptor
        {
            set
            {
                this.productIssuesGrid.ItemsSource = value;
                this.productIssuesGrid.Items.Refresh();

            }
        }
    }
}
