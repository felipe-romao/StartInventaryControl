using NUnit.Framework;
using StartInventaryControl.Data;
using StartInventaryControl.Repository;
using StartInventaryControl.Repository.NHibernate;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartInventaryControl.UnitTest.Repository
{
    public class ProductRepositoryTest
    {
        private static readonly string DB_FILE = @"..\..\..\resource\DB\SQLite\DB.sqlite";
        private static readonly string DB_FILE_TMP = DB_FILE + ".tmp";

        private readonly IProductRepository repository;

        public ProductRepositoryTest()
        {
            this.repository = new ProductRepository();
        }

        [SetUp]
        public void SetUp()
        {
            File.Copy(DB_FILE, DB_FILE_TMP, true);
        }

        [Test]
        public void AddProduct_ProductIsNull_ThrowException()
        {
            var ex = Assert.Throws<RepositoryException>(() => this.repository.Add(null));

            Assert.That(ex.Message, Is.EqualTo("O produto não pode estar nulo ou vazio."));
        }

        [Test]
        public void AddProduct_ProductAlreadyExists_ThrowException()
        {
            var product = ProductHelperTest.CreateProductExisting();

            var ex = Assert.Throws<RepositoryException>(() => this.repository.Add(product));

            Assert.That(ex.Message, Is.EqualTo("Produto 'CAMISA' já existe."));
        }

        [Test]
        public void AddProduct_ProductIsValid_GetAllProductAdded()
        {
            var product = ProductHelperTest.CreateProductValid();

            this.repository.Add(product);

            var products = this.repository.GetAll();

            Assert.That(products.Count, Is.EqualTo(2));

            Assert.That(products[0].Description, Is.EqualTo("CAMISA"));
            Assert.That(products[1].Description, Is.EqualTo("CAMISETA"));
        }

        [Test]
        public void UpdateProduct_ProductIsNull_ThrowException()
        {
            var ex = Assert.Throws<RepositoryException>(() => this.repository.Update(null));

            Assert.That(ex.Message, Is.EqualTo("O produto não pode estar nulo ou vazio."));
        }

        [Test]
        public void UpdateProduct_ProductUpdatedAlreadyExists_ThrowException()
        {
            var product = ProductHelperTest.CreateProductValid();

            this.repository.Add(product);
            var productUpdated = this.repository.GetAll()[1];

            productUpdated.Description = "CAMISA";

            var ex = Assert.Throws<RepositoryException>(() => this.repository.Update(productUpdated));

            Assert.That(ex.Message, Is.EqualTo("Produto 'CAMISA' já existe."));
        }

        [Test]
        public void UpdateProduct_ProductIsValid_GetProductUpdated()
        {
            var product = this.repository.GetAll()[0];
            Assert.That(product.Description, Is.EqualTo("CAMISA"));
            
            product.Description = "CAMISA AB";
            this.repository.Update(product);

            var productUpdated = this.repository.GetAll()[0];
            Assert.That(productUpdated.Description, Is.EqualTo("CAMISA AB"));
        }
    }
}
