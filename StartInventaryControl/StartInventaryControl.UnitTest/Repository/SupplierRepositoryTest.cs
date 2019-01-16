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
    [TestFixture]
    public class SupplierRepositoryTest
    {
        private static readonly string DB_FILE = @"..\..\..\resource\DB\SQLite\DB.sqlite";
        private static readonly string DB_FILE_TMP = DB_FILE + ".tmp";

        private readonly ISupplierRepository repository;

        public SupplierRepositoryTest()
        {
            this.repository = new SupplierRepository();
        }

        [SetUp]
        public void SetUp()
        {
            File.Copy(DB_FILE, DB_FILE_TMP, true);
        }

        [Test]
        public void AddSupplier_SupplierIsNull_ThrowException()
        {
            var ex = Assert.Throws<RepositoryException>(() => this.repository.Add(null));

            Assert.That(ex.Message, Is.EqualTo("O fornecedor não pode estar nulo ou vazio."));
        }

        [Test]
        public void AddSupplier_SupplierAlreadyExists_ThrowException()
        {
            var supplier = new Supplier
            {
                Name = "FORNECEDOR_1",
            };

            var ex = Assert.Throws<RepositoryException>(() => this.repository.Add(supplier));

            Assert.That(ex.Message, Is.EqualTo("Fornecedor 'FORNECEDOR_1' já existe."));
        }

        [Test]
        public void AddSupplier_SupplierIsValid_GetAllSupplierAdded()
        {
            var supplier = new Supplier
            {
                Name = "FORNECEDOR_2",
            };

            this.repository.Add(supplier);

            var suppliers = this.repository.GetAll();

            Assert.That(suppliers.Count, Is.EqualTo(2));
            Assert.That(suppliers[0].Name, Is.EqualTo("FORNECEDOR_1"));
            Assert.That(suppliers[1].Name, Is.EqualTo("FORNECEDOR_2"));

        }

        [Test]
        public void UpdateSupplier_SupplierIsNull_ThrowException()
        {
            var ex = Assert.Throws<RepositoryException>(() => this.repository.Update(null));

            Assert.That(ex.Message, Is.EqualTo("O fornecedor não pode estar nulo ou vazio."));
        }

        [Test]
        public void UpdateSupplier_SupplierUpdatedAlreadyExists_ThrowException()
        {
            var supplier = new Supplier
            {
                Name = "FORNECEDOR_2",
            };

            this.repository.Add(supplier);
            var suppliers = this.repository.GetAll();

            suppliers[1].Name = "FORNECEDOR_1";
            var ex = Assert.Throws<RepositoryException>(() => this.repository.Update(suppliers[1]));

            Assert.That(ex.Message, Is.EqualTo("Fornecedor 'FORNECEDOR_1' já existe."));
        }

        [Test]
        public void UpdateSupplier_SupplierIsValid_GetSupplierUpdated()
        {
            var supplier = this.repository.GetAll()[0];
            Assert.That(supplier.Name, Is.EqualTo("FORNECEDOR_1"));

            supplier.Name = "FORNECEDOR_2";
            this.repository.Update(supplier);

            var supplierUpdated = this.repository.GetAll()[0];
            Assert.That(supplierUpdated.Name, Is.EqualTo("FORNECEDOR_2"));
        }
    }
}
