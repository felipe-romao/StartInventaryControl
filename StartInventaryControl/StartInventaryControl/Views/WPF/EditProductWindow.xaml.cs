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
using System.ComponentModel;

namespace StartInventaryControl.Views.WPF
{
    /// <summary>
    /// Interaction logic for EditProductWindow.xaml
    /// </summary>
    public partial class EditProductWindow : Window, IEditProductView, IDisposable
    {
        private IList<Variation> variations;

        public EditProductWindow()
        {
            InitializeComponent();
            this.uploadImageButton.Click      += (sender, args) => this.Presenter.OnUploadedImage();
            this.saveButton.Click             += (sender, args) => this.Presenter.OnSalvedProduct();
            this.updateVariationsButton.Click += (sender, args) => this.Presenter.OnAddedNewVariationsExisting();
            this.cancelButton.Click           += (sender, args) => this.Close();
            this.Closing                      += this.ConfirmationDialog;
        }

        public EditProductPresenter Presenter
        {
            private get;
            set;
        }

        public string Annotation
        {
            get
            {
                return this.annotationTextBox.Text;
            }

            set
            {
                this.annotationTextBox.Text = value;
            }
        }

        public string Description
        {
            get
            {
                return this.descriptionTextBox.Text;
            }

            set
            {
                this.descriptionTextBox.Text = value;
            }
        }

        public string ImagePath
        {
            get
            {
                return this.imagePathTextBox.Text;
            }

            set
            {
                this.imagePathTextBox.Text = value;
            }
        }

        public IList<Variation> Variations
        {
            get
            {
                //return variationsGrid.ItemsSource as List<Variation>;
                return this.variations;
            }

            set
            {
                this.variations = value;
                this.variationsGrid.ItemsSource = this.variations;
                this.variationsGrid.Items.Refresh();
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

        public bool HasUnsavedChanges
        {
            get; set;
        }

        public string ChooseLogFileToOpen()
        {
            var dialog = new OpenFileDialog();
            var ok = dialog.ShowDialog().GetValueOrDefault(false);
            return ok ? dialog.FileName : null;
        }

        public void Dispose()
        {
            this.Close();
        }

        private void ConfirmationDialog(object sender, CancelEventArgs e)
        {
            if (!this.HasUnsavedChanges) return;

            var messageBoxResult = MessageBox.Show("Você tem certeza que deseja descartar as alterações?", "Confirmação para fechar", MessageBoxButton.YesNo);
            e.Cancel = messageBoxResult == MessageBoxResult.No;
        }
    }
}
    