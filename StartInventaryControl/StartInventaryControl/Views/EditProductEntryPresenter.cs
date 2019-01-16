using NLog;
using StartInventaryControl.Data;
using StartInventaryControl.Factory;
using StartInventaryControl.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Transactions;

namespace StartInventaryControl.Views
{
    public class EditProductEntryPresenter
    {
        private static Logger LOGGER = LogManager.GetCurrentClassLogger();

        private readonly IEditProductEntryView view;
        private readonly ISupplierRepository supplierRepository;
        private readonly IProductRepository productRepository;
        private readonly IProductEntryRepository productEntryRepository;

        public EditProductEntryPresenter(IEditProductEntryView view, ISupplierRepository supplierRepository, IProductRepository productRepository, IProductEntryRepository productEntryRepository)
        {
            this.view                   = view;
            this.supplierRepository     = supplierRepository;
            this.productRepository      = productRepository;
            this.productEntryRepository = productEntryRepository;
        }

        public void Initialize()
        {
            try
            {
                this.view.Presenter         = this;
                this.view.Suppliers         = this.supplierRepository.GetAll();
                this.view.Products          = this.productRepository.GetAll();
                this.view.ProductEntryItems = new List<ProdutEntryItemDescriptor>();
                this.view.Date              = DateTime.Now;
            }
            catch(Exception ex)
            {
                throw new Exception($"Um erro occoreu ao tentar editar esta entrada de produto: {ex.Message}", ex);
            }
        }

        public void OnSelectedProduct()
        {
            try
            {
                if (this.view.Product == null)
                    return;

                this.view.ProductEntryItems = new List<ProdutEntryItemDescriptor>();
                this.view.imagePath         = !string.IsNullOrEmpty(this.view.Product.ImagePath) 
                                                        ? Path.Combine(DataHelpers.ProductImagePath, this.view.Product.ImagePath) 
                                                        : DataHelpers.ProductImagePathNotFound;
                this.view.Genders           = this.view.Product.GetAllGenders();
                this.view.Sizes             = null;
                this.view.Colors            = null;
                this.view.SelectedGender    = null;
                this.view.SelectedColor     = null;
                this.view.ProductEntryItems = new List<ProdutEntryItemDescriptor>();
                this.view.HasUnsavedChanges = true;
            }
            catch(Exception ex)
            {
                LOGGER.Error($"Error while selected product: {ex.ToString()}");
                this.view.ErrorMessage = $"Não foi possível selecionar o produto:{ex.Message}";
            }
        }

        public void OnSelectedGender()
        {
            try
            {
                if (this.view.Product == null)
                    return;

                var gender       = this.view.SelectedGender;
                this.view.Colors = this.view.Product.GetAllColorsByGender(gender);
                this.view.Sizes  = null;;
                this.view.SelectedColor     = null;
                this.view.HasUnsavedChanges = true;
            }
            catch(Exception ex)
            {
                LOGGER.Error($"Error while selected gender: {ex.ToString()}");
                this.view.ErrorMessage = $"Não foi possível selecionar o genero:{ex.Message}";
            }
        }

        public void OnSelectedColor()
        {
            try
            {
                if (this.view.Product == null)
                    return;

                var gender      = this.view.SelectedGender;
                var color       = this.view.SelectedColor;
                this.view.Sizes = this.view.Product.GetAllSizesByGenderAndColor(gender, color);
                this.view.HasUnsavedChanges = true;
            }
            catch(Exception ex)
            {
                LOGGER.Error($"Error while selected color: {ex.ToString()}");
                this.view.ErrorMessage = $"Não foi possível selecionar a cor:{ex.Message}";
            }
        }

        public void OnAddedProductEntryItem()
        {
            try
            {
                if (!this.ValidateProdutEntryItem())
                {
                    return;
                }

                var quantityBySize  = this.view.QuantityBySize;
                var gender          = this.view.SelectedGender;
                var color           = this.view.SelectedColor;
                var items           = new List<ProdutEntryItemDescriptor>();

                foreach(var size in quantityBySize.Keys)
                {
                    if (quantityBySize[size] == -1)
                    {
                        this.view.InfoMessage = $"Tamanho '{size}' contem uma quantidade inválida!";
                        return;
                    }
                    var item = new ProdutEntryItemDescriptor
                    {
                        Color    = color,
                        Gender   = gender,
                        Size     = size,
                        Quantity = quantityBySize[size],
                    };
                    items.Add(item);
                }
                this.view.InsertProductEntryItem(items);
                this.view.HasUnsavedChanges = true;
            }
            catch(Exception ex)
            {
                LOGGER.Error($"Error while added product entry item: {ex.ToString()}");
                this.view.ErrorMessage = $"Não foi possível adicionar o item desta entrada de produto:{ex.Message}";
            }
        }

        public void OnDeletedProductEntryItem()
        {
            try
            {
                var index = this.view.SelectedProductEntryItemIndex;
                if (index >= 0)
                {
                    this.view.RemoveProductEntryItem(index);
                    this.view.InfoMessage = "Variação removida com sucesso!";
                    return;
                }
                this.view.ErrorMessage = "Selecione uma variação para ser removida!";
                this.view.HasUnsavedChanges = true;
            }
            catch (Exception ex)
            {
                LOGGER.Error($"Error while deleted product entry item: {ex.ToString()}");
                this.view.ErrorMessage = $"Não foi possível deletar o item desta entrada de produto:{ex.Message}";
            }
        }

        public void OnAddedNewProductEntry()
        {
            try
            {
                if (!ValidateProductEntry())
                {
                    return;
                }

                var product             = this.view.Product;
                var supplier            = this.view.Supplier;
                var annotation          = this.view.Annotation;
                var date                = this.view.Date;
                var productEntryItems   = new List<ProductEntryItem>();

                var productEntry = new ProductEntry
                {
                    Annotation          = annotation,
                    Code                = Guid.NewGuid().ToString(),
                    Product             = product,
                    Date                = date,
                    Supplier            = supplier,
                    ProductEntryItems   = productEntryItems,
                };

                foreach (var item in this.view.ProductEntryItems)
                {
                    var productEntryItem = new ProductEntryItem
                    {
                        ProductEntry    = productEntry,
                        Quantity        = item.Quantity,
                        Variation       = product.GetProductVariation(item.Gender, item.Color, item.Size)
                    };
                    productEntryItems.Add(productEntryItem);
                }

                this.productEntryRepository.Add(productEntry);
                this.ClearProductInfoInView();

                this.view.HasUnsavedChanges = false;
                this.view.InfoMessage = $"Entrada adicionada com sucesso!!";
            }
            catch (Exception ex)
            {
                LOGGER.Error($"Error while salved product entry: {ex.ToString()}");
                this.view.ErrorMessage = $"Erro ao adicionar esta entrada: {ex.Message}";
            }


        }

        private void ClearProductInfoInView()
        {
            this.view.Product  = null;
            this.view.Products = this.productRepository.GetAll();
            this.view.Genders  = null;
            this.view.Colors   = null;
            this.view.Sizes    = null;
            this.view.ProductEntryItems = new List<ProdutEntryItemDescriptor>();
        }

        private bool ValidateProductEntry()
        {
            if (this.view.Supplier == null)
            {
                this.view.ErrorMessage = "Selecione um fornecedor!";
                return false;
            }

            if (!this.ValidateProdutEntryItem())
            {
                return false;
            }

            if (this.view.ProductEntryItems == null || this.view.ProductEntryItems.Count == 0)
            {
                this.view.ErrorMessage = "Adicione as variações e suas quantidades!";
                return false;
            }

            return true;
        }

        private bool ValidateProdutEntryItem()
        {
            if (this.view.Product == null)
            {
                this.view.ErrorMessage = "Selecione um produto!";
                return false;
            }

            if (this.view.SelectedGender == null)
            {
                this.view.ErrorMessage = "Selecione um genero!";
                return false;
            }

            if (this.view.SelectedColor == null)
            {
                this.view.ErrorMessage = "Selecione uma cor!";
                return false;
            }

            if (this.view.QuantityBySize == null || this.view.QuantityBySize.Count == 0)
            {
                this.view.ErrorMessage = "Adicione as quantidades por tamanho!";
                return false;
            }

            return true;
        }
    }
}
