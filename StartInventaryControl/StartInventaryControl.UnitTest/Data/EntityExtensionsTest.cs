using NUnit.Framework;
using StartInventaryControl.Data;
using System;
using System.Collections.Generic;

namespace StartInventaryControl.UnitTest.Data
{
    [TestFixture]
    public class EntityExtensionsTest
    {
        [Test]
        public void ValidateProdutEntry_ProductEntryIsNull_ThrowException()
        {
            ProductEntry productEntry = null;

            var ex = Assert.Throws<ArgumentException>(() => productEntry.Valid());

            Assert.That(ex.Message, Is.EqualTo("Entrada de produto não pode estar nula ou vazia."));
        }

        [Test]
        public void ValidateProductEntry_SupplierIsNull_ThrowException()
        {
            var productEntry = new ProductEntry
            {
                Code = "CODE_1",
            };

            var ex = Assert.Throws<ArgumentException>(() => productEntry.Valid());

            Assert.That(ex.Message, Is.EqualTo("Entrada de produto sem fornecedor."));
        }

        [Test]
        public void ValidateProductEntry_ProductIsNull_ThrowException()
        {
            var productEntry = new ProductEntry
            {
                Code = "CODE_1",
                Supplier = new Supplier { Name = "SUPPLIER_1" }
            };

            var ex = Assert.Throws<ArgumentException>(() => productEntry.Valid());

            Assert.That(ex.Message, Is.EqualTo("Entrada de produto sem produto."));
        }

        [Test]
        public void ValidateProdutIssue_ProductIssueIsNull_ThrowException()
        {
            ProductIssue productIssue = null;

            var ex = Assert.Throws<ArgumentException>(() => productIssue.Valid());

            Assert.That(ex.Message, Is.EqualTo("Saida de produto não pode estar nula ou vazia."));
        }

        [Test]
        public void ValidateProductIssue_ProductIsNull_ThrowException()
        {
            var outputOrder = new ProductIssue
            {
                Code = "CODE_1",
            };

            var ex = Assert.Throws<ArgumentException>(() => outputOrder.Valid());

            Assert.That(ex.Message, Is.EqualTo("Saida de produto sem produto."));
        }

        //[Test]
        //public void ValidateWorkOrder_WorkOrderIsNull_ThrowExcepiton()
        //{
        //    WorkOrder workOrder = null;

        //    var ex = Assert.Throws<ArgumentException>(() => workOrder.Valid());

        //    Assert.That(ex.Message, Is.EqualTo("Ordem de serviço não pode estar nula ou vazia."));
        //}

        //[Test]
        //public void ValidateWorkOrder_SupplierIsNull_ThrowExcepiton()
        //{
        //    var workOrder = new WorkOrder
        //    {
        //        ID = 1,
        //        Code = "CODE_1",
        //        Date = DateTime.Now,
        //    };

        //    var ex = Assert.Throws<ArgumentException>(() => workOrder.Valid());

        //    Assert.That(ex.Message, Is.EqualTo("Ordem de serviço sem fornecedor."));
        //}

        //[Test]
        //public void ValidateWorkOrder_ProductItemsAreNull_ThrowExcepiton()
        //{
        //    var workOrder = new WorkOrder
        //    {
        //        ID = 1,
        //        Code = "CODE_1",
        //        Date = DateTime.Now,
        //        Supplier = new Supplier { ID = 1, Name = "FORNECEDOR_1" },
        //    };

        //    var ex = Assert.Throws<ArgumentException>(() => workOrder.Valid());

        //    Assert.That(ex.Message, Is.EqualTo("Ordem de serviço sem itens."));
        //}

        //[Test]
        //public void ValidateWorkOrder_ProductItemsAreEmpty_ThrowExcepiton()
        //{
        //    var workOrder = new WorkOrder
        //    {
        //        ID = 1,
        //        Code = "CODE_1",
        //        Date = DateTime.Now,
        //        Supplier = new Supplier { ID = 1, Name = "FORNECEDOR_1" },
        //        WorkOrderProduct = new List<WorkOrderProduct>()
        //    };

        //    var ex = Assert.Throws<ArgumentException>(() => workOrder.Valid());

        //    Assert.That(ex.Message, Is.EqualTo("Ordem de serviço sem itens."));
        //}

        //[Test]
        //public void ValidateWorkOrder_ProductItemsContainsItemNull_ThrowExcepiton()
        //{
        //    var product = new Product
        //    {
        //        Code = "CODE_PROD_1",
        //        Color = new Color { ID = 1, Name = "AZUL" },
        //        Size = "G",
        //        Gender = "FEMININO",
        //        Quantity = 10,
        //        Model = new Model { ID = 1, Name = "MODELO_1" }
        //    };

        //    var items = new List<WorkOrderProduct>
        //        {
        //            new WorkOrderProduct { ID = 1, Quantity = 2, Product = product },
        //            null
        //        };

        //    var workOrder = new WorkOrder
        //    {
        //        ID = 1,
        //        Code = "CODE_1",
        //        Date = DateTime.Now,
        //        Supplier = new Supplier { ID = 1, Name = "FORNECEDOR_1" },
        //        WorkOrderProduct = items
        //    };

        //    var ex = Assert.Throws<ArgumentException>(() => workOrder.Valid());

        //    Assert.That(ex.Message, Is.EqualTo("Ordem de serviço contém um item vazio."));
        //}

        //[Test]
        //public void ValidateWorkOrder_ProductItemsContainsItemWithProductNull_ThrowExcepiton()
        //{
        //    var items = new List<WorkOrderProduct>
        //    {
        //        new WorkOrderProduct { ID = 1, Quantity = 2, Product = null },
        //    };

        //    var workOrder = new WorkOrder
        //    {
        //        ID = 1,
        //        Code = "CODE_1",
        //        Date = DateTime.Now,
        //        Supplier = new Supplier { ID = 1, Name = "FORNECEDOR_1" },
        //        WorkOrderProduct = items
        //    };

        //    var ex = Assert.Throws<ArgumentException>(() => workOrder.Valid());

        //    Assert.That(ex.Message, Is.EqualTo("Ordem de serviço contém um item sem produto."));
        //}

        //[Test]
        //public void ValidateWorkOrder_WorkOrderIsValid_DoesNotThrowException()
        //{
        //    var product = new Product
        //    {
        //        Code = "CODE_PROD_1",
        //        Color = new Color { ID = 1, Name = "AZUL" },
        //        Size = "G",
        //        Gender = "FEMININO",
        //        Quantity = 10,
        //        Model = new Model { ID = 1, Name = "MODELO_1" }
        //    };

        //    var items = new List<WorkOrderProduct>
        //        {
        //            new WorkOrderProduct { ID = 1, Quantity = 2, Product = product },
        //        };

        //    var workOrder = new WorkOrder
        //    {
        //        ID = 1,
        //        Code = "CODE_1",
        //        Date = DateTime.Now,
        //        Supplier = new Supplier { ID = 1, Name = "FORNECEDOR_1" },
        //        WorkOrderProduct = items
        //    };

        //    Assert.DoesNotThrow(() => workOrder.Valid());
        //}
    }
}
