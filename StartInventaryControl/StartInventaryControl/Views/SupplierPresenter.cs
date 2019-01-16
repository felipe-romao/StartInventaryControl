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
    public class SupplierPresenter
    {
        private static Logger LOGGER = LogManager.GetCurrentClassLogger();

        private readonly ISupplierView view;
        private readonly ApplicationController appController;
        private readonly ISupplierRepository repository;

        public SupplierPresenter(ISupplierView view, ApplicationController appController, ISupplierRepository repository)
        {
            this.view          = view;
            this.appController = appController;
            this.repository    = repository;
        }

        public void Initialize()
        {
            try
            {
                this.view.Presenter = this;
                this.view.Suppliers = this.repository.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception($"Um erro occoreu ao tentar listar os fornecedores: {ex.Message}", ex);
            }
        }

        public void OnAddedSupplier()
        {
            try
            {
                this.appController.HandleEditSupplier(new Supplier());
                this.view.Suppliers = this.repository.GetAll();
            }
            catch (Exception ex)
            {
                LOGGER.Error($"Error while added supplier: {ex.ToString()}");
                this.view.ErrorMessage = $"Não foi possível adicionar o fornecedor: {ex.Message}.";
            }
        }

        public void OnUpdatedSupplier()
        {
            try
            {
                var supplier = this.view.Supplier;
                if (supplier == null)
                {
                    return;
                }
                this.appController.HandleEditSupplier(supplier);
                this.view.Suppliers = this.repository.GetAll();
            }
            catch (Exception ex)
            {
                LOGGER.Error($"Error while updated supplier: {ex.ToString()}");
                this.view.ErrorMessage = $"Não foi possível atualizar o fornecedor: {ex.Message}.";
            }
        }
    }
}
