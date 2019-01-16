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
    public class ProductEntryPresenter
    {
        private static Logger LOGGER = LogManager.GetCurrentClassLogger();

        private readonly IProductEntryView view;
        private readonly ApplicationController appController;
        private readonly IProductEntryRepository repository;

        public ProductEntryPresenter(IProductEntryView view, ApplicationController appController, IProductEntryRepository repository)
        {
            this.view = view;
            this.appController = appController;
            this.repository = repository;
        }

        public void Initialize()
        {
            try
            {
                this.view.Presenter = this;
                this.view.ProductEntriesDescriptor = this.GetProductEntriesDescriptor();
            }
            catch (Exception ex)
            {
                throw new Exception($"Um erro occoreu ao tentar listar as entradas de produto: {ex.Message}", ex);
            }
        }

        public void OnAddedNewProductEntry()
        {
            try
            {
                this.appController.HandleEditProductEntry();
                this.view.ProductEntriesDescriptor = this.GetProductEntriesDescriptor();
            }
            catch (Exception ex)
            {
                LOGGER.Error($"Error while added product entry: {ex.ToString()}");
                this.view.ErrorMessage = $"Não foi possível adicionar uma entrada de produto: {ex.Message}.";
            }
        }

        private List<ProdutEntryDescriptor> GetProductEntriesDescriptor()
        {
            var list = new List<ProdutEntryDescriptor>();
            foreach(var productEntry in this.repository.GetAll())
            {
                list.AddRange(productEntry.GetProductEntriesDescriptor());
            }
            return list;
        }
    }
}
