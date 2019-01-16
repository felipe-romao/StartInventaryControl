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
    public class VariationTypePresenter
    {
        private static Logger LOGGER = LogManager.GetCurrentClassLogger();

        private readonly IVariationTypeView view;
        private readonly ApplicationController appController;
        private readonly IVariationTypeRepository repository;

        public VariationTypePresenter(IVariationTypeView view, ApplicationController appController, IVariationTypeRepository repository)
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
                this.view.VariationTypes = this.repository.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception($"Um erro occoreu ao tentar listar as variações: {ex.Message}", ex);
            }
        }

        public void OnAddedVariationType()
        {
            try
            {
                this.appController.HandleEditVariationType(new VariationType());
                this.view.VariationTypes = this.repository.GetAll();
            }
            catch (Exception ex)
            {
                LOGGER.Error($"Error while added variation type: {ex.ToString()}");
                this.view.ErrorMessage = $"Não foi possível adicionar a variação: {ex.Message}.";
            }
        }

        public void OnDeletedVariationType()
        {
            try
            {
                var variationType = this.view.VariationType;
                if (variationType == null)
                {
                    return;
                }

                this.repository.Delete(variationType);
                this.view.InfoMessage = "Variação deletada com sucesso!";
                this.view.VariationTypes = this.repository.GetAll();
            }
            catch (Exception ex)
            {
                LOGGER.Error($"Error while deleted variation type: {ex.ToString()}");
                this.view.ErrorMessage = $"Não foi possível deletar a variação: {ex.Message}.";
            }
        }
    }
}
