using NUnit.Framework;
using StartInventaryControl.Data;
using StartInventaryControl.Repository;
using StartInventaryControl.Repository.NHibernate;
using System;
using System.IO;
using System.Linq;

namespace StartInventaryControl.UnitTest.Repository
{
    public class ProductEntryRepositoryTest
    {
        private static readonly string DB_FILE = @"..\..\..\resource\DB\SQLite\DB.sqlite";
        private static readonly string DB_FILE_TMP = DB_FILE + ".tmp";

        private readonly IProductEntryRepository repository;

        public ProductEntryRepositoryTest()
        {
            this.repository = new ProductEntryRepository();
        }

        [SetUp]
        public void SetUp()
        {
            File.Copy(DB_FILE, DB_FILE_TMP, true);
        }

        [Test]
        public void AddProductEntry_ProductEntryAlreadyExists_ThrowException()
        {
            var productEntry = ProductEntryHelperTest.CreateProductEntryExisting();

            var ex = Assert.Throws<RepositoryException>(() => this.repository.Add(productEntry));

            Assert.That(ex.Message, Is.EqualTo("Entrada de produto 'CODE_1' já existe."));
        }

        [Test]
        public void AddProductEntry_ProductEntryIsValid_GetWorkOrderAdded()
        {
            var productEntry = ProductEntryHelperTest.CreateProductEntryValid();

            this.repository.Add(productEntry);

            var productEntryAdded = this.repository.GetByCode("CODE_2");

            Assert.That(productEntryAdded.Code                                  , Is.EqualTo("CODE_2"));
            Assert.That(productEntryAdded.Supplier.Name                         , Is.EqualTo("FORNECEDOR_1"));
            Assert.That(productEntryAdded.Product.Description                   , Is.EqualTo("CAMISA"));
            Assert.That(productEntryAdded.ProductEntryItems.Count               , Is.EqualTo(1));
            Assert.That(productEntryAdded.ProductEntryItems[0].Quantity         , Is.EqualTo(2));
            Assert.That(productEntryAdded.ProductEntryItems[0].Variation.Gender , Is.EqualTo("FEMININO"));
            Assert.That(productEntryAdded.ProductEntryItems[0].Variation.Color  , Is.EqualTo("AZUL"));
            Assert.That(productEntryAdded.ProductEntryItems[0].Variation.Size   , Is.EqualTo("M"));
        }

        [Test]
        public void GetAllProductEntry_ListIsValid_ReturnAllProductEntries()
        {
            var entries = this.repository.GetAll();

            Assert.That(entries.Count, Is.EqualTo(1));

            var productEntry = entries.First();

            Assert.That(productEntry.Product.Description                    , Is.EqualTo("CAMISA"));
            Assert.That(productEntry.Code                                   , Is.EqualTo("CODE_1"));
            Assert.That(productEntry.Supplier.Name                          , Is.EqualTo("FORNECEDOR_1"));
            Assert.That(productEntry.Product.Description                    , Is.EqualTo("CAMISA"));
            Assert.That(productEntry.ProductEntryItems.Count                , Is.EqualTo(1));
            Assert.That(productEntry.ProductEntryItems[0].Quantity          , Is.EqualTo(4));
            Assert.That(productEntry.ProductEntryItems[0].Variation.Gender  , Is.EqualTo("FEMININO"));
            Assert.That(productEntry.ProductEntryItems[0].Variation.Color   , Is.EqualTo("AZUL"));
            Assert.That(productEntry.ProductEntryItems[0].Variation.Size    , Is.EqualTo("M"));
        }

        //[Test]
        //public void UpdateProductEntry_ProductEntryUpdatedAlreadyExists_ThrowException()
        //{
        //    var product = new Product
        //    {
        //        ID = 1,
        //        Code = "CODE_1",
        //        Color = new Color { ID = 1, Name = "AZUL" },
        //        Size = "M",
        //        Gender = "MASCULINO",
        //        Quantity = 10,
        //        Model = new Model { ID = 1, Name = "MODELO_1" }
        //    };

        //    var productEntry = new ProductEntry
        //    {
        //        ID = 2,
        //        Code = "CODE_2",
        //        Date = DateTime.Now,
        //        Supplier = new Supplier { ID = 1, Name = "FORNECEDOR_1" },
        //        Product = product
        //    };

        //    this.repository.Add(productEntry);

        //    productEntry.Code = "CODE_1";

        //    var ex = Assert.Throws<RepositoryException>(() => this.repository.Update(productEntry));

        //    Assert.That(ex.Message, Is.EqualTo("Entrada de produto 'CODE_1' já existe."));
        //}

        //[Test]
        //public void UpdateProductEntry_ProductEntryIsValid_GetWorkOrderUpdated()
        //{
        //    var productEntry = this.repository.GetByCode("CODE_1");
        //    Assert.That(productEntry.Quantity, Is.EqualTo(8));
        //    Assert.That(productEntry.Product.Description, Is.EqualTo("MODELO_1 - MASCULINO - AZUL - TAMANHO M"));

        //    productEntry.Code = "CODE_3";
        //    productEntry.Quantity = 12;
        //    this.repository.Update(productEntry);

        //    var productEntryUpdated = this.repository.GetByCode("CODE_3");
        //    Assert.That(productEntryUpdated.Quantity, Is.EqualTo(12));
        //    Assert.That(productEntryUpdated.Product.Description, Is.EqualTo("MODELO_1 - MASCULINO - AZUL - TAMANHO M"));
        //}
    }
}
