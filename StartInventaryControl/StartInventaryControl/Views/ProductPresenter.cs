using NLog;
using StartInventaryControl.Data;
using StartInventaryControl.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartInventaryControl.Views
{
    public class ProductPresenter
    {
        private static Logger LOGGER = LogManager.GetCurrentClassLogger();

        private readonly IProductView view;
        private readonly ApplicationController appController;
        private readonly IProductRepository repository;
        private readonly IReportCreator reportCreator;
        private List<Variation> variations;

        public ProductPresenter(IProductView view, ApplicationController appController, IProductRepository repository, IReportCreator reportCreator)
        {
            this.view          = view;
            this.appController = appController;
            this.repository    = repository;
            this.reportCreator = reportCreator;
        }

        public void Initialize()
        {
            try
            {
                this.view.Presenter = this;
                this.GetVariations();
            }
            catch (Exception ex)
            {
                throw new Exception($"Um erro occoreu ao tentar listar os produtos: {ex.Message}", ex);
            }
        }

        public void OnAddedProduct()
        {
            try
            {
                this.appController.HandleEditProduct(new Product());
                this.GetVariations();
            }
            catch (Exception ex)
            {
                LOGGER.Error($"Error while added product: {ex.ToString()}");
                this.view.ErrorMessage = $"Não foi possível adicionar o produto: {ex.Message}.";
            }
        }

        public void OnUpdatedProduct()
        {
            try
            {
                var product = this.view.Product;
                this.appController.HandleEditProduct(product);
                this.GetVariations();
            }
            catch (Exception ex)
            {
                LOGGER.Error($"Error while updated product: {ex.ToString()}");
                this.view.ErrorMessage = $"Não foi possível atualizar o produto: {ex.Message}.";
            }
        }

        public void OnExportedAllProducts()
        {
            try
            {
                var xlsxFile = this.view.ChooseSalveXLSXFileToOpen();
                if (string.IsNullOrEmpty(xlsxFile))
                {
                    this.view.ErrorMessage = "Informar o nome do arquvo XLSX.";
                    return;
                }

                this.reportCreator.Create(xlsxFile, this.variations);
                this.view.InfoMessage = "Relatório criado com sucesso!";
            }
            catch (Exception ex)
            {
                LOGGER.Error($"Error while exported product list: {ex.ToString()}");
                this.view.ErrorMessage = $"Ocorreu um erro na geração da planilha: {ex.Message}.";
            }
        }

        private void GetVariations()
        {
            this.variations = new List<Variation>();
            foreach(var product in this.repository.GetAll())
            {
                this.variations.AddRange(product.Variations);
            }
            this.view.Variations = this.variations;
        }
    }
}
