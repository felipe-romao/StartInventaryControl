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
    public class WorkOrderRepositoryTest
    {
        private static readonly string DB_FILE = @"..\..\..\resource\DB\SQLite\DB.sqlite";
        private static readonly string DB_FILE_TMP = DB_FILE + ".tmp";

        private readonly IWorkOrderRepository repository;

        public WorkOrderRepositoryTest()
        {
            this.repository = new WorkOrderRepository();
        }

        [SetUp]
        public void SetUp()
        {
            File.Copy(DB_FILE, DB_FILE_TMP, true);
        }

        [Test]
        public void AddWorkOrder_ProductAlreadyExists_ThrowException()
        {
            var product = new Product
            {
                Code = "CODE_1",
                Color = new Color { ID = 1, Name = "AZUL" },
                Size = "M",
                Gender = "MASCULINO",
                Quantity = 10,
                Model = new Model { ID = 1, Name = "MODELO_1" }
            };

            var items = new List<WorkOrderProduct>
                {
                    new WorkOrderProduct { ID = 1, Quantity = 2, Product = product }
                };

            var workOrder = new WorkOrder
            {
                ID = 1,
                Code = "CODE_1",
                Date = DateTime.Now,
                Supplier = new Supplier { ID = 1, Name = "FORNECEDOR_1" },
                WorkOrderProduct = items
                };

            var ex = Assert.Throws<RepositoryException>(() => this.repository.Add(workOrder));

            Assert.That(ex.Message, Is.EqualTo("Ordem de serviço 'CODE_1' já existe."));
        }

        [Test]
        public void AddWorkOrder_WorkOrderIsValid_GetWorkOrderAdded()
        {
            var product = new Product
            {
                ID = 1,
                Code = "CODE_1",
                Color = new Color { ID = 1, Name = "AZUL" },
                Size = "M",
                Gender = "MASCULINO",
                Quantity = 10,
                Model = new Model { ID = 1, Name = "MODELO_1" }
            };

            var items = new List<WorkOrderProduct>
                {
                    new WorkOrderProduct { Quantity = 2, Product = product }
                };

            var workOrder = new WorkOrder
            {
                Code = "CODE_2",
                Date = DateTime.Now,
                Supplier = new Supplier { ID = 1, Name = "FORNECEDOR_1" },
                WorkOrderProduct = items
            };

            items[0].WorkOrder = workOrder;

            this.repository.Add(workOrder);

            var workOrderAdded = this.repository.GetByCode("CODE_2");

            Assert.That(workOrderAdded.Code                                     , Is.EqualTo("CODE_2"));
            Assert.That(workOrderAdded.Supplier.Name                            , Is.EqualTo("FORNECEDOR_1"));
            Assert.That(workOrderAdded.WorkOrderProduct.Count                   , Is.EqualTo(1));
            Assert.That(workOrderAdded.WorkOrderProduct[0].Quantity             , Is.EqualTo(2));
            Assert.That(workOrderAdded.WorkOrderProduct[0].Product.Description  , Is.EqualTo("MODELO_1 - MASCULINO - AZUL - TAMANHO M"));
        }

        [Test]
        public void GetAllWorkOrder_ListIsValid_ReturnAllWorkOrders()
        {
            var workOrders = this.repository.GetAll();

            Assert.That(workOrders.Count, Is.EqualTo(1));

            Assert.That(workOrders[0].WorkOrderProduct.Count                 , Is.EqualTo(1));
            Assert.That(workOrders[0].WorkOrderProduct[0].Product.Description, Is.EqualTo("MODELO_1 - MASCULINO - AZUL - TAMANHO M"));
            Assert.That(workOrders[0].WorkOrderProduct[0].Quantity           , Is.EqualTo(8));
        }

        [Test]
        public void UpdateWorkOrder_WorkOrderUpdatedAlreadyExists_ThrowException()
        {
            var product = new Product
            {
                ID = 1,
                Code = "CODE_1",
                Color = new Color { ID = 1, Name = "AZUL" },
                Size = "M",
                Gender = "MASCULINO",
                Quantity = 10,
                Model = new Model { ID = 1, Name = "MODELO_1" }
            };

            var items = new List<WorkOrderProduct>
                {
                    new WorkOrderProduct { Quantity = 3, Product = product }
                };

            var workOrder = new WorkOrder
            {
                ID = 2,
                Code = "CODE_2",
                Date = DateTime.Now,
                Supplier = new Supplier { ID = 1, Name = "FORNECEDOR_1" },
                WorkOrderProduct = items
            };

            items[0].WorkOrder = workOrder;

            this.repository.Add(workOrder);

            workOrder.Code = "CODE_1";

            var ex = Assert.Throws<RepositoryException>(() => this.repository.Update(workOrder));

            Assert.That(ex.Message, Is.EqualTo("Ordem de serviço 'CODE_1' já existe."));
        }

        [Test]
        public void UpdateWorkOrder_WorkOrderIsValid_GetWorkOrderUpdated()
        {
            var workOrder = this.repository.GetByCode("CODE_1");
            Assert.That(workOrder.WorkOrderProduct.Count                    , Is.EqualTo(1));
            Assert.That(workOrder.WorkOrderProduct[0].Quantity              , Is.EqualTo(8));
            Assert.That(workOrder.WorkOrderProduct[0].Product.Description   , Is.EqualTo("MODELO_1 - MASCULINO - AZUL - TAMANHO M"));

            workOrder.Code = "CODE_3";
            workOrder.WorkOrderProduct[0].Quantity = 12;
            this.repository.Update(workOrder);

            var productUpdated = this.repository.GetByCode("CODE_3");
            Assert.That(workOrder.WorkOrderProduct.Count                    , Is.EqualTo(1));
            Assert.That(workOrder.WorkOrderProduct[0].Quantity              , Is.EqualTo(12));
            Assert.That(workOrder.WorkOrderProduct[0].Product.Description   , Is.EqualTo("MODELO_1 - MASCULINO - AZUL - TAMANHO M"));
        }

        [Test]
        public void UpdateWorkOrder_AddNewProduct_GetWorkOrderUpdated()
        {
            var workOrder = this.repository.GetByCode("CODE_1");

            Assert.That(workOrder.WorkOrderProduct.Count                    , Is.EqualTo(1));
            Assert.That(workOrder.WorkOrderProduct[0].Quantity              , Is.EqualTo(8));
            Assert.That(workOrder.WorkOrderProduct[0].Product.Description   , Is.EqualTo("MODELO_1 - MASCULINO - AZUL - TAMANHO M"));

            var newProduct = new Product
            {
                ID = 2,
                Code = "CODE_4",
                Color = new Color { ID = 1, Name = "AZUL" },
                Size = "P",
                Gender = "FEMININO",
                Quantity = 7,
                Model = new Model { ID = 1, Name = "MODELO_1" }
            };

            var newWorkOrderProduct = new WorkOrderProduct
            {
                Product = newProduct,
                WorkOrder = workOrder,
                Quantity = 3
            };

            workOrder.WorkOrderProduct.Add(newWorkOrderProduct);

            this.repository.Update(workOrder);

            var productUpdated = this.repository.GetByCode("CODE_1");

            Assert.That(workOrder.WorkOrderProduct.Count                    , Is.EqualTo(2));
            Assert.That(workOrder.WorkOrderProduct[0].Quantity              , Is.EqualTo(8));
            Assert.That(workOrder.WorkOrderProduct[0].Product.Description   , Is.EqualTo("MODELO_1 - MASCULINO - AZUL - TAMANHO M"));
            Assert.That(workOrder.WorkOrderProduct[1].Quantity              , Is.EqualTo(3));
            Assert.That(workOrder.WorkOrderProduct[1].Product.Description   , Is.EqualTo("MODELO_1 - FEMININO - AZUL - TAMANHO P"));
        }
    }
}
