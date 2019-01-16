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
    /// Interaction logic for VariationTypeWindow.xaml
    /// </summary>
    public partial class VariationTypeWindow : Window, IVariationTypeView
    {
        public VariationTypeWindow()
        {
            InitializeComponent();

            this.addVariationButton.Click    += (sender, args) => this.Presenter.OnAddedVariationType();
            this.deleteVariationButton.Click += (sender, args) => this.Presenter.OnDeletedVariationType();
        }

        public VariationTypePresenter Presenter
        {
            set; private get;
        }

        public VariationType VariationType
        {
            get
            {
                return this.variationTypeGrid.SelectedItem as VariationType;
            }
        }

        public IList<VariationType> VariationTypes
        {
            set
            {
                this.variationTypeGrid.ItemsSource = value;
                this.variationTypeGrid.Items.Refresh();
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
    }
}
