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
    /// Interaction logic for EditSupplierWindow.xaml
    /// </summary>
    public partial class EditSupplierWindow : Window, IEditSupplierView
    {
        public EditSupplierWindow()
        {
            InitializeComponent();

            this.salveSupperButton.Click += (sender, args) => this.Presenter.OnSalvedSupplier();
        }

        public EditSupplierPresenter Presenter
        {
            set; private get;
        }

        public string SupplierName
        {
            get
            {
                return this.nameTextBox.Text;
            }

            set
            {
                this.nameTextBox.Text = value;
            }
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

        public void Dispose()
        {
            this.Close();
        }
    }
}
