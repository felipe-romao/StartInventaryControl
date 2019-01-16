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
    public class EditVariationTypePresenter
    {
        private static Logger LOGGER = LogManager.GetCurrentClassLogger();

        private readonly IEditVariationTypeView view;
        private readonly IVariationTypeRepository repository;
        private VariationType variationType;

        public EditVariationTypePresenter(IEditVariationTypeView view, VariationType variationType, IVariationTypeRepository repository)
        {
            this.view = view;
            this.repository = repository;
            this.variationType = variationType;
        }

        public void Initialize()
        {
            this.view.Presenter = this;
            this.view.VariationTypes = VariationType.TYPES;
        }

        public void OnSalvedVariationType()
        {
            try
            {
                var variationType = this.view.VariationType;
                var variationValue = this.view.VariationValue;

                if (string.IsNullOrEmpty(variationType))
                {
                    this.view.InfoMessage = "Informe um tipo";
                    return;
                }

                if (string.IsNullOrEmpty(variationValue))
                {
                    this.view.InfoMessage = "Informe um valor";
                    return;
                }

                this.variationType.Type = variationType.ToUpper();
                this.variationType.Value = variationValue.ToUpper();

                this.repository.Add(this.variationType);
                EntityExtensions.UpdateAllVariationsStatic(this.repository.GetAll());

                this.view.InfoMessage = "Variação salva com sucesso!";
                this.view.Dispose();
            }
            catch(Exception ex)
            {
                LOGGER.Error($"Error while salved variation type:{ex.Message}");
                this.view.ErrorMessage = $"Não foi possível salvar esta variação: {ex.Message}";

            }
        }
    }
}
