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
using System.Data;
using System.Text.RegularExpressions;
using System.ComponentModel;

namespace StartInventaryControl.Views.WPF
{
    /// <summary>
    /// Interaction logic for EditProductEntryWindow.xaml
    /// </summary>
    public partial class EditProductEntryWindow : Window, IEditProductEntryView, IDisposable
    {
        private IList<ProdutEntryItemDescriptor> productEntryItem;

        public EditProductEntryWindow()
        {
            InitializeComponent();
            InitializeSizeGrid();

            this.productDescComboBox.SelectionChanged   += (sender, args) => this.Presenter.OnSelectedProduct();
            this.genderComboBox.SelectionChanged        += (sender, args) => this.Presenter.OnSelectedGender();
            this.colorComboBox.SelectionChanged         += (sender, args) => this.Presenter.OnSelectedColor();
            this.createEntryButton.Click                += (sender, args) => this.Presenter.OnAddedProductEntryItem();
            this.removeEntryButton.Click                += (sender, args) => this.Presenter.OnDeletedProductEntryItem();
            this.saveButton.Click                       += (sender, args) => this.Presenter.OnAddedNewProductEntry();
            this.cancelButton.Click                     += (sender, args) => this.Close();
            this.Closing                                +=  this.ConfirmationDialog;
        }

        private void InitializeSizeGrid()
        {
            var dt = new DataTable();
            dt.Columns.Add(new DataColumn("PP"));
            dt.Columns.Add(new DataColumn("P"));
            dt.Columns.Add(new DataColumn("M"));
            dt.Columns.Add(new DataColumn("G"));
            dt.Columns.Add(new DataColumn("GG"));
            dt.Columns.Add(new DataColumn("xG"));
            dt.Rows.Add(dt.NewRow());

            this.sizesGrid.IsEnabled   = false;
            this.sizesGrid.ItemsSource = dt.DefaultView;
            this.sizesGrid.Items.Refresh();
        }

        public EditProductEntryPresenter Presenter
        {
            private get;
            set;
        }

        public Supplier Supplier
        {
            get
            {
                return this.supplierComboBox.SelectedItem as Supplier;
            }

            set
            {
                this.supplierComboBox.SelectedValue = value;
            }
        }

        public IList<Supplier> Suppliers
        {
            set
            {
                this.supplierComboBox.ItemsSource = value;
            }
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

        public DateTime Date
        {
            get
            {
                return date.SelectedDate.Value;
            }

            set
            {
                this.date.SelectedDate = value;
            }
        }

        public string imagePath
        {
            set
            {
                var imageSource = new BitmapImage(new Uri(value));
                this.productImage.Source = imageSource;
            }
        }

        public IList<Product> Products
        {
            set
            {
                this.productDescComboBox.ItemsSource = value;
            }
        }

        public Product Product
        {
            get
            {
                return this.productDescComboBox.SelectedItem as Product;
            }

            set
            {
                this.productDescComboBox.SelectedValue = value;
            }
        }

        public IList<ProdutEntryItemDescriptor> ProductEntryItems
        {
            get
            {
                return this.productEntryItem;
            }
            set
            {
                this.productEntryItem = value;
                this.EntriesGrid.ItemsSource = this.productEntryItem;
                this.EntriesGrid.Items.Refresh();
            }
        }

        public IList<string> Genders
        {
            set
            {
                this.genderComboBox.ItemsSource = value;
            }
        }

        public IList<string> Colors
        {
            set
            {
                this.colorComboBox.ItemsSource = value;
            }
        }

        public IList<string> Sizes
        {
            set
            {
                if (value == null)
                {
                    this.InitializeSizeGrid();
                    return;
                }
                
                var dt = new DataTable();
                foreach (var size in value)
                {
                    dt.Columns.Add(size);
                }
                dt.Rows.Add(dt.NewRow());

                this.sizesGrid.IsEnabled = true;
                this.sizesGrid.ItemsSource = dt.DefaultView;
                this.sizesGrid.Items.Refresh();
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

        public int SelectedProductEntryItemIndex
        {
            get
            {
                return this.EntriesGrid.SelectedIndex;
            }
        }

        public string SelectedGender
        {
            get
            {
                return this.genderComboBox.SelectedValue as string;
            }
            set
            {
                this.genderComboBox.SelectedValue = value;
            }
        }

        public string SelectedColor
        {
            get
            {
                return this.colorComboBox.SelectedValue as string;
            }
            set
            {
                this.colorComboBox.SelectedValue = value;
            }
        }

        public IDictionary<string, int> QuantityBySize
        {
            get
            {
                this.sizesGrid.CancelEdit(DataGridEditingUnit.Row);
                var row  = this.sizesGrid.ItemContainerGenerator.ContainerFromIndex(0) as DataGridRow;
                var data = new Dictionary<string, int>();

                foreach(var sizeColumn in this.sizesGrid.Columns)
                {
                    var quantity = this.ConvertSizeNumberToInt((sizeColumn.GetCellContent(row) as TextBlock).Text);
                    if(quantity != 0)
                    {
                        data.Add(sizeColumn.Header.ToString(), quantity);
                    }
                }
                return data;
            }
        }

        private int ConvertSizeNumberToInt(string size)
        {
            try
            {
                if (!string.IsNullOrEmpty(size))
                {
                    if (!Regex.IsMatch(size, @"^[0-9]+$"))
                    {
                        return -1;
                    }
                    return Convert.ToInt32(size);
                }
                return 0;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public void InsertProductEntryItem(IList<ProdutEntryItemDescriptor> items)
        {
            foreach(var item in items)
            {
                this.productEntryItem.Add(item);
            }
            
            this.EntriesGrid.Items.Refresh();
        }

        public void RemoveProductEntryItem(int index)
        {
            this.productEntryItem.RemoveAt(index);
            this.EntriesGrid.Items.Refresh();
        }

        public bool HasUnsavedChanges {get; set; }

        public bool HasUnsavedProductChanges { get; set; }

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
