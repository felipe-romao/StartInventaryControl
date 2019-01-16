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
    public class EditSupplierPresenter
    {
        private static Logger LOGGER = LogManager.GetCurrentClassLogger();

        private readonly IEditSupplierView view;
        private readonly ISupplierRepository repository;
        private Supplier supplier;

        public EditSupplierPresenter(IEditSupplierView view, Supplier supplier, ISupplierRepository repository)
        {
            this.view       = view;
            this.supplier   = supplier;
            this.repository = repository;
        }

        public void Initialize()
        {
            try
            {
                this.view.Presenter = this;
                this.view.SupplierName = this.supplier.Name;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao tentar editar o fornecedor: {ex.Message}", ex);
            }
        }

        public void OnSalvedSupplier()
        {
            try
            {
                if (string.IsNullOrEmpty(this.view.SupplierName))
                {
                    return;
                }

                this.supplier.Name = this.view.SupplierName;
                if (this.supplier.IsNew)
                {
                    this.repository.Add(this.supplier);
                }
                else
                {
                    this.repository.Update(this.supplier);
                }
                this.view.InfoMessage = "Fornecedor salvo com sucesso!";
                this.view.Dispose();
            }
            catch (Exception ex)
            {
                LOGGER.Error($"Error while salved supplier:{ex.Message}");
                this.view.ErrorMessage = $"Não foi possível salvar este fornecedor: {ex.Message}";
            }
        }
    }
}
