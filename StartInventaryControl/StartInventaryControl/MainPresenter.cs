using NLog;
using StartInventaryControl.Repository;
using StartInventaryControl.Repository.NHibernate;
using StartInventaryControl.Views;
using StartInventaryControl.Views.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartInventaryControl
{
    public class MainPresenter
    {
        private static Logger LOGGER = LogManager.GetCurrentClassLogger();

        private readonly IMainView view;
        private readonly ApplicationController controller;

        public MainPresenter(IMainView view, ApplicationController controller)
        {
            this.view = view;
            this.controller = controller;
        }

        public void Initialize()
        {
            this.view.Presenter = this;
        }

        public void OnProductEntry()
        {
            try
            {
                this.controller.HandleProductEntry();
            }
            catch(Exception ex)
            {
                LOGGER.Error($"Error while show product entries: {ex.ToString()}");
                this.view.ErrorMessage = $"Não foi possível exibir as entradas de estoque: {ex.Message}.";
            }
        }

        public void OnEditProductEntry()
        {
            try
            {
                this.controller.HandleEditProductEntry();
            }
            catch (Exception ex)
            {
                LOGGER.Error($"Error while edit product entry: {ex.ToString()}");
                this.view.ErrorMessage = $"Não foi possível editar a entrada de estoque: {ex.Message}.";
            }
        }

        public void OnProductIssue()
        {
            try
            {
                this.controller.HandleProductIssue();
            }
            catch (Exception ex)
            {
                LOGGER.Error($"Error while show product issues: {ex.ToString()}");
                this.view.ErrorMessage = $"Não foi possível exibir as saidas de estoque: {ex.Message}.";
            }
        }

        public void OnEditProductIssue()
        {
            try
            {
                this.controller.HandleEditProductIssue();
            }
            catch (Exception ex)
            {
                LOGGER.Error($"Error while edit product issue: {ex.ToString()}");
                this.view.ErrorMessage = $"Não foi possível editar a saida de estoque: {ex.Message}.";
            }
        }

        public void OnProduct()
        {
            try
            {
                this.controller.HandleProducts();
            }
            catch (Exception ex)
            {
                LOGGER.Error($"Error while show products: {ex.ToString()}");
                this.view.ErrorMessage = $"Não foi possível exibir os produtos cadastrados: {ex.Message}.";
            }
        }

        public void OnEditProduct()
        {
            try
            {
                this.controller.HandleEditProduct(new Data.Product());
            }
            catch (Exception ex)
            {
                LOGGER.Error($"Error while edit product: {ex.ToString()}");
                this.view.ErrorMessage = $"Não foi possível editar o produto: {ex.Message}.";
            }
        }

        public void OnSupplier()
        {
            try
            {
                this.controller.HandleSuppliers();
            }
            catch (Exception ex)
            {
                LOGGER.Error($"Error while show suppliers: {ex.ToString()}");
                this.view.ErrorMessage = $"Não foi possível exibir os fornecedores cadastrados: {ex.Message}.";
            }
        }

        public void OnEditSupplier()
        {
            try
            {
                this.controller.HandleEditSupplier(new Data.Supplier());
            }
            catch (Exception ex)
            {
                LOGGER.Error($"Error while edit supplier: {ex.ToString()}");
                this.view.ErrorMessage = $"Não foi possível editar o fornecedor: {ex.Message}.";
            }
        }

        public void OnVariationType()
        {
            try
            {
                this.controller.HandleVariationTypes();
            }
            catch (Exception ex)
            {
                LOGGER.Error($"Error while show variation types: {ex.ToString()}");
                this.view.ErrorMessage = $"Não foi possível exibir as variações cadastradas: {ex.Message}.";
            }
        }

        public void OnEditVariationType()
        {
            try
            {
                this.controller.HandleEditVariationType(new Data.VariationType());
            }
            catch (Exception ex)
            {
                LOGGER.Error($"Error while edit variation type: {ex.ToString()}");
                this.view.ErrorMessage = $"Não foi possível editar a variação: {ex.Message}.";
            }
        }
    }
}
