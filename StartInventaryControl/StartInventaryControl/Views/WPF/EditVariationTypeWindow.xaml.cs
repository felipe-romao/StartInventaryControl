using StartInventaryControl.Data;
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
    /// Interaction logic for EditVariationTypeWindow.xaml
    /// </summary>
    public partial class EditVariationTypeWindow : Window, IEditVariationTypeView
    {
        public EditVariationTypeWindow()
        {
            InitializeComponent();

            this.salveVariationTypeButton.Click += (sender, args) => this.Presenter.OnSalvedVariationType();
        }

        public EditVariationTypePresenter Presenter
        {
            set;
            private get;
        }

        public string VariationType => this.variationTypeCombobox.SelectedItem as string;

        public IList<string> VariationTypes
        {
            set
            {
                this.variationTypeCombobox.ItemsSource = value;
                this.variationTypeCombobox.Items.Refresh();
            }
        }

        public string VariationValue
        {
            get
            {
                return variationValueTextBox.Text;
            }

            set
            {
                variationValueTextBox.Text = value;
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
