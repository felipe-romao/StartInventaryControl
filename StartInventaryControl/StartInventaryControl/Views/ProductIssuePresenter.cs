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
    public class ProductIssuePresenter
    {
        private static Logger LOGGER = LogManager.GetCurrentClassLogger();

        private readonly IProductIssueView view;
        private readonly ApplicationController appController;
        private readonly IProductIssueRepository repository;

        public ProductIssuePresenter(IProductIssueView view, ApplicationController appController, IProductIssueRepository repository)
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
                this.view.ProductIssuesDescriptor = this.GetProductIssuesDescriptor();
            }
            catch(Exception ex)
            {
                throw new Exception($"Um erro occoreu ao tentar listar as saidas de produto: {ex.Message}", ex);
            }
        }

        public void OnAddedNewProductIssue()
        {
            try
            {
                this.appController.HandleEditProductIssue();
                this.view.ProductIssuesDescriptor = this.GetProductIssuesDescriptor();
            }
            catch (Exception ex)
            {
                LOGGER.Error($"Error while added product entry: {ex.ToString()}");
                this.view.ErrorMessage = $"Não foi possível adicionar uma entrada de produto: {ex.Message}.";
            }
        }

        private List<ProdutIssueDescriptor> GetProductIssuesDescriptor()
        {
            var list = new List<ProdutIssueDescriptor>();
            foreach (var productIssue in this.repository.GetAll())
            {
                list.AddRange(productIssue.GetProductIssuesDescriptor());
            }
            return list;
        }
    }
}
