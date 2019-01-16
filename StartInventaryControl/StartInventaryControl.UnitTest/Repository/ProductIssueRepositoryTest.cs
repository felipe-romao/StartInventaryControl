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
    public class ProductIssueRepositoryTest
    {
        private static readonly string DB_FILE = @"..\..\..\resource\DB\SQLite\DB.sqlite";
        private static readonly string DB_FILE_TMP = DB_FILE + ".tmp";

        private readonly IProductIssueRepository repository;

        //public ProductIssueRepositoryTest()
        //{
        //    this.repository = new ProductIssueRepository();
        //}

        //[SetUp]
        //public void SetUp()
        //{
        //    File.Copy(DB_FILE, DB_FILE_TMP, true);
        //}

        //[Test]
        //public void AddProductIssue_ProductIssueAlreadyExists_ThrowException()
        //{
        //    var product = new Product
        //    {
        //        Code = "CODE_1",
        //        Color = new Color { ID = 1, Name = "AZUL" },
        //        Size = "M",
        //        Gender = "MASCULINO",
        //        Quantity = 10,
        //        Model = new Model { ID = 1, Name = "MODELO_1" }
        //    };

        //    var productIssue = new ProductIssue
        //    {
        //        ID = 1,
        //        Code = "CODE_1",
        //        Date = DateTime.Now,
        //        Quantity = 8,
        //        Product = product
        //    };

        //    var ex = Assert.Throws<RepositoryException>(() => this.repository.Add(productIssue));

        //    Assert.That(ex.Message, Is.EqualTo("Saida de produto 'CODE_1' já existe."));
        //}

        //[Test]
        //public void AddProductIssue_ProductIssueIsValid_GetWorkOrderAdded()
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

        //    var productIssue = new ProductIssue
        //    {
        //        Code = "CODE_2",
        //        Date = DateTime.Now,
        //        Quantity = 2,
        //        Product = product
        //    };

        //    this.repository.Add(productIssue);

        //    var productIssueAdded = this.repository.GetByCode("CODE_2");

        //    Assert.That(productIssueAdded.Code, Is.EqualTo("CODE_2"));
        //    Assert.That(productIssueAdded.Quantity, Is.EqualTo(2));
        //    Assert.That(productIssueAdded.Product.Description, Is.EqualTo("MODELO_1 - MASCULINO - AZUL - TAMANHO M"));
        //}

        //[Test]
        //public void GetAllProductIssue_ListIsValid_ReturnAllProductIssues()
        //{
        //    var issues = this.repository.GetAll();

        //    Assert.That(issues.Count, Is.EqualTo(1));

        //    Assert.That(issues.Count, Is.EqualTo(1));
        //    Assert.That(issues[0].Product.Description, Is.EqualTo("MODELO_1 - MASCULINO - AZUL - TAMANHO M"));
        //    Assert.That(issues[0].Quantity, Is.EqualTo(8));
        //}

        //[Test]
        //public void UpdateProductIssue_ProductIssueUpdatedAlreadyExists_ThrowException()
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

        //    var productIssue = new ProductIssue
        //    {
        //        ID = 2,
        //        Code = "CODE_2",
        //        Date = DateTime.Now,
        //        Product = product
        //    };

        //    this.repository.Add(productIssue);

        //    productIssue.Code = "CODE_1";

        //    var ex = Assert.Throws<RepositoryException>(() => this.repository.Update(productIssue));

        //    Assert.That(ex.Message, Is.EqualTo("Saida de produto 'CODE_1' já existe."));
        //}

        //[Test]
        //public void UpdateProductIssue_ProductIssueIsValid_GetWorkOrderUpdated()
        //{
        //    var productIssue = this.repository.GetByCode("CODE_1");
        //    Assert.That(productIssue.Quantity, Is.EqualTo(8));
        //    Assert.That(productIssue.Product.Description, Is.EqualTo("MODELO_1 - MASCULINO - AZUL - TAMANHO M"));

        //    productIssue.Code = "CODE_3";
        //    productIssue.Quantity = 12;
        //    this.repository.Update(productIssue);

        //    var productIssueUpdated = this.repository.GetByCode("CODE_3");
        //    Assert.That(productIssueUpdated.Quantity, Is.EqualTo(12));
        //    Assert.That(productIssueUpdated.Product.Description, Is.EqualTo("MODELO_1 - MASCULINO - AZUL - TAMANHO M"));
        //}
    }
}
