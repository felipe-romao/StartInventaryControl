using StartInventaryControl.Data;
using StartInventaryControl.Repository;
using StartInventaryControl.Repository.NHibernate;

namespace StartInventaryControl
{
    public class Bootstrapper
    {
        public Bootstrapper()
        {
            this.InitializeRepositories();
            this.InitializeServices();
            EntityExtensions.UpdateAllVariationsStatic(this.VariationTypeRepository.GetAll());
        }

        public IProductRepository ProductRepository { get; private set; }
        public IProductEntryRepository ProductEntryRepository { get; private set; }
        public IProductIssueRepository ProductIssueRepository { get; private set; }
        public ISupplierRepository SupplierRepository { get; private set; }
        public IVariationTypeRepository VariationTypeRepository { get; private set; }
        public IFileService FileService { get; private set; }
        public IReportCreator ReportCreator { get; private set; }

        private void InitializeRepositories()
        {
            this.SupplierRepository     = new SupplierRepository();
            this.ProductRepository      = new ProductRepository();
            this.ProductEntryRepository = new ProductEntryRepository();
            this.ProductIssueRepository = new ProductIssueRepository();
            this.VariationTypeRepository = new VariationTypeRepository();
        }

        public void InitializeServices()
        {
            this.FileService   = new OSFileService();
            this.ReportCreator = new XLSXReportCreator();
        }
    }
}
