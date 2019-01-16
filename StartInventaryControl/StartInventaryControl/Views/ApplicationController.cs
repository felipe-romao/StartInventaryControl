using StartInventaryControl.Data;
using StartInventaryControl.Repository;
using StartInventaryControl.Views.WPF;
using System.Collections.Generic;

namespace StartInventaryControl.Views
{
    public class ApplicationController
    {
        private readonly ISupplierRepository supplierRepository;
        private readonly IProductRepository productRepository;
        private readonly IProductEntryRepository productEntryRepository;
        private readonly IProductIssueRepository productIssueRepository;
        private readonly IVariationTypeRepository variationTypeRepository;
        private readonly IFileService fileService;
        private readonly IReportCreator reportCreator;

        public ApplicationController(Bootstrapper bootstrapper)
        {
            this.supplierRepository     = bootstrapper.SupplierRepository;
            this.productRepository      = bootstrapper.ProductRepository;
            this.productEntryRepository = bootstrapper.ProductEntryRepository;
            this.productIssueRepository = bootstrapper.ProductIssueRepository;
            this.variationTypeRepository = bootstrapper.VariationTypeRepository;
            this.fileService            = bootstrapper.FileService;
            this.reportCreator          = bootstrapper.ReportCreator;
        }

        public void Initialize()
        {
            var view = new MainWindow(this);
            view.ShowDialog();
        }

        public void HandleProductEntry()
        {
            var view = new ProdutEntryWindow();
            var presenter = new ProductEntryPresenter(view, this, productEntryRepository);
            presenter.Initialize();
            view.ShowDialog();
        }

        public void HandleEditProductEntry()
        {
            var view = new EditProductEntryWindow();
            var presenter = new EditProductEntryPresenter(view, supplierRepository, productRepository, productEntryRepository);
            presenter.Initialize();
            view.ShowDialog();
        }

        public void HandleProductIssue()
        {
            var view = new ProductIssueWindow();
            var presenter = new ProductIssuePresenter(view, this, productIssueRepository);
            presenter.Initialize();
            view.ShowDialog();
        }

        public void HandleEditProductIssue()
        {
            var view = new EditProductIssueWindow();
            var presenter = new EditProductIssuePresenter(view, productRepository, productIssueRepository);
            presenter.Initialize();
            view.ShowDialog();
        }

        public void HandleProducts()
        {
            var view = new ProductWindow();
            var presenter = new ProductPresenter(view, this, productRepository, this.reportCreator);
            presenter.Initialize();
            view.ShowDialog();
        }

        public void HandleEditProduct(Product product)
        {
            var view = new EditProductWindow();
            var presenter = new EditProductPresenter(view, product, productRepository, this.fileService, DataHelpers.Genders, DataHelpers.Colors, DataHelpers.Sizes);
            presenter.Initialize();
            view.ShowDialog();
        }

        public void HandleSuppliers()
        {
            var view = new SupplierWindow();
            var presenter = new SupplierPresenter(view, this, supplierRepository);
            presenter.Initialize();
            view.ShowDialog();
        }

        public void HandleEditSupplier(Supplier supplier)
        {
            var view = new EditSupplierWindow();
            var presenter = new EditSupplierPresenter(view, supplier, supplierRepository);
            presenter.Initialize();
            view.ShowDialog();
        }

        public void HandleVariationTypes()
        {
            var view = new VariationTypeWindow();
            var presenter = new VariationTypePresenter(view, this, variationTypeRepository);
            presenter.Initialize();
            view.ShowDialog();
        }

        public void HandleEditVariationType(VariationType variationType)
        {
            var view = new EditVariationTypeWindow();
            var presenter = new EditVariationTypePresenter(view, variationType, variationTypeRepository);
            presenter.Initialize();
            view.ShowDialog();
        }
    }
}
