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
    public class EditProductPresenter
    {
        private static Logger LOGGER = LogManager.GetCurrentClassLogger();

        private readonly IEditProductView view;
        private readonly IProductRepository repository;
        private readonly IFileService fileService;
        private readonly IList<string> Genders;
        private readonly IList<string> Colors;
        private readonly IList<string> Sizes;
        private Product product;

        public EditProductPresenter(IEditProductView view, Product product, IProductRepository repository, IFileService fileService, IList<string> Genders, IList<string> Colors, IList<string> Sizes)
        {
            this.view       = view;
            this.product    = product;
            this.repository = repository;
            this.fileService = fileService;
            this.Genders    = Genders;
            this.Colors     = Colors;
            this.Sizes      = Sizes;
        }

        public void Initialize()
        {
            try
            {
                this.InitializeVariationsInProduct();

                this.view.Presenter   = this;
                this.view.Variations  = this.product.Variations;
                this.view.Description = this.product.Description;
                this.view.Annotation  = this.product.Annotation;
                this.view.ImagePath   = this.product.ImagePath;
                this.view.HasUnsavedChanges = false;
            }
            catch(Exception ex)
            {
                throw new Exception($"Um erro occoreu ao tentar editar este produto: {ex.Message}", ex);
            }
        }
        
        private void InitializeVariationsInProduct()
        {
            if (!this.product.HasVariations)
            {
                this.product.Variations = this.product.CreateVariations(this.Genders, this.Colors, this.Sizes);
            }
        }

        public void OnUploadedImage()
        {
            try
            {
                this.view.HasUnsavedChanges = true;

                var imagePath = this.view.ChooseLogFileToOpen();
                if (string.IsNullOrEmpty(imagePath))
                {
                    return;
                }

                var imageBytes    = this.fileService.ReadAllBytes(imagePath);
                var imageName     = Path.GetFileName(imagePath);
                var imageFilePath = Path.Combine(DataHelpers.ProductImagePath, imageName);

                this.fileService.WriteAllBytes(imageBytes, imageFilePath);
                this.view.ImagePath = imageName;
            }
            catch(Exception ex)
            {
                LOGGER.Error($"Error while uploaded image: {ex.ToString()}");
                this.view.ErrorMessage = $"Não foi possível fazer o upload desta imagem: {ex.Message}.";
            }
        }

        public void OnAddedNewVariationsExisting()
        {
            try
            {
                this.view.HasUnsavedChanges = true;
                this.product.AddVariationsNoExists(this.Genders, this.Colors, this.Sizes);
                this.view.Variations = this.product.Variations;
            }
            catch(Exception ex)
            {
                LOGGER.Error($"Error while add news variations existing: {ex.ToString()}");
                this.view.ErrorMessage = $"Não foi possível fazer a inclusão das novas variações: {ex.Message}.";
            }
        }

        public void OnSalvedProduct()
        {
            try
            {
                this.ValidateProduct();
                this.PopulateProduct();

                if (this.product.IsNew)
                {
                    this.repository.Add(this.product);
                }
                else
                {
                    this.repository.Update(product);
                }
                this.view.InfoMessage = "Produto salvo com sucesso!";
                this.view.HasUnsavedChanges = false;
            }
            catch (Exception ex)
            {
                LOGGER.Error($"Error while salved product: {ex.ToString()}");
                this.view.ErrorMessage = $"Não foi possível salvar este produto: {ex.Message}.";
            }
        }

        private void ValidateProduct()
        {
            if(this.view.Variations == null || this.view.Variations.Count == 0)
            {
                throw new Exception("Nenhuma variação encontrada.");
            }
            if (string.IsNullOrEmpty(this.view.Description))
            {
                throw new Exception("Informe uma descrição.");
            }
        }

        private void PopulateProduct()
        {
            this.view.HasUnsavedChanges = true;
            this.product.Variations  = this.view.Variations;
            this.product.Description = this.view.Description;
            this.product.Annotation  = this.view.Annotation;
            this.product.ImagePath   = this.view.ImagePath;
        }
    }
}
