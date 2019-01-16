using NLog;
using StartInventaryControl.Data;
using StartInventaryControl.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartInventaryControl.Views
{
    public class EditProductIssuePresenter
    {
        private static Logger LOGGER = LogManager.GetCurrentClassLogger();

        private readonly IEditProductIssueView view;
        private readonly IProductRepository productRepository;
        private readonly IProductIssueRepository productIssueRepository;

        public EditProductIssuePresenter(IEditProductIssueView view, IProductRepository productRepository, IProductIssueRepository productIssueRepository)
        {
            this.view                   = view;
            this.productRepository      = productRepository;
            this.productIssueRepository = productIssueRepository;
        }

        public void Initialize()
        {
            try
            {
                this.view.Presenter         = this;
                this.view.Products          = this.productRepository.GetAll();
                this.view.ProductIssueItems = new List<ProductIssueItemDescriptor>();
                this.view.Date              = DateTime.Now;
            }
            catch (Exception ex)
            {
                throw new Exception($"Um erro occoreu ao tentar editar esta saida de produto: {ex.Message}", ex);
            }
        }

        public void OnSelectedProduct()
        {
            try
            {
                if (this.view.Product == null)
                    return;

                this.view.ProductIssueItems = new List<ProductIssueItemDescriptor>();
                this.view.imagePath = !string.IsNullOrEmpty(this.view.Product.ImagePath)
                                                        ? Path.Combine(DataHelpers.ProductImagePath, this.view.Product.ImagePath)
                                                        : DataHelpers.ProductImagePathNotFound;
                this.view.Genders           = this.view.Product.GetAllGenders();
                this.view.Sizes             = null;
                this.view.Colors            = null;
                this.view.SelectedGender    = null;
                this.view.SelectedColor     = null;
                this.view.ProductIssueItems = new List<ProductIssueItemDescriptor>();
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
                this.view.SelectedColor = null;
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

        public void OnAddedProductIssueItem()
        {
            try
            {
                if (!this.ValidateProdutIssueItem())
                {
                    return;
                }

                var quantityBySize  = this.view.QuantityBySize;
                var gender          = this.view.SelectedGender;
                var color           = this.view.SelectedColor;
                var items           = new List<ProductIssueItemDescriptor>();

                foreach(var size in quantityBySize.Keys)
                {
                    if (quantityBySize[size] == -1)
                    {
                        this.view.InfoMessage = $"Tamanho '{size}' contem uma quantidade inválida!";
                        return;
                    }
                    var item = new ProductIssueItemDescriptor
                    {
                        Color    = color,
                        Gender   = gender,
                        Size     = size,
                        Quantity = quantityBySize[size],
                    };

                    var product = this.view.Product;
                    product.CheckProductIssueQuantity(item);

                    items.Add(item);
                }
                this.view.InsertProductIssueItem(items);
                this.view.HasUnsavedChanges = true;
            }
            catch(Exception ex)
            {
                LOGGER.Error($"Error while added product issue item: {ex.ToString()}");
                this.view.ErrorMessage = $"Não foi possível adicionar o item desta saida de produto:{ex.Message}";
            }
        }

        public void OnDeletedProductIssueItem()
        {
            try
            {
                var index = this.view.SelectedProductIssueItemIndex;
                if (index >= 0)
                {
                    this.view.RemoveProductIssueItem(index);
                    this.view.InfoMessage = "Variação removida com sucesso!";
                    return;
                }
                this.view.ErrorMessage = "Selecione uma variação para ser removida!";
                this.view.HasUnsavedChanges = true;
            }
            catch(Exception ex)
            {
                LOGGER.Error($"Error while deleted product issue item: {ex.ToString()}");
                this.view.ErrorMessage = $"Não foi possível deletar o item desta saida de produto:{ex.Message}";
            }
        }

        public void OnAddedNewProductIssue()
        {
            try
            {
                if (!ValidateProductIssue())
                {
                    return;
                }

                var product             = this.view.Product;
                var annotation          = this.view.Annotation;
                var date                = this.view.Date;
                var productIssueItems   = new List<ProductIssueItem>();

                var productIssue = new ProductIssue
                {
                    Annotation          = annotation,
                    Code                = Guid.NewGuid().ToString(),
                    Product             = product,
                    Date                = date,
                    ProductIssueItems   = productIssueItems,
                };

                foreach (var item in this.view.ProductIssueItems)
                {
                    var productIssueItem = new ProductIssueItem
                    {
                        ProductIssue    = productIssue,
                        Quantity        = item.Quantity,
                        Variation       = product.GetProductVariation(item.Gender, item.Color, item.Size)
                    };
                    productIssueItems.Add(productIssueItem);
                }

                this.productIssueRepository.Add(productIssue);
                this.ClearProductInfoInView();

                this.view.HasUnsavedChanges = false;
                this.view.InfoMessage = $"Saida adicionada com sucesso!!";
            }
            catch (Exception ex)
            {
                LOGGER.Error($"Error while salved product issue: {ex.ToString()}");
                this.view.ErrorMessage = $"Erro ao adicionar esta saida: {ex.Message}";
            }
        }

        private void ClearProductInfoInView()
        {
            this.view.Product  = null;
            this.view.Products = this.productRepository.GetAll();
            this.view.Genders  = null;
            this.view.Colors   = null;
            this.view.Sizes    = null;
            this.view.ProductIssueItems = new List<ProductIssueItemDescriptor>();
        }

        private bool ValidateProductIssue()
        {
            if (!this.ValidateProdutIssueItem())
            {
                return false;
            }

            if (this.view.ProductIssueItems == null || this.view.ProductIssueItems.Count == 0)
            {
                this.view.ErrorMessage = "Adicione as variações e suas quantidades!";
                return false;
            }

            return true;
        }

        private bool ValidateProdutIssueItem()
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
