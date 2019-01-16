using StartInventaryControl.Data;
using StartInventaryControl.Repository.NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StartInventaryControl.UnitTest.Repository
{
    public static class ProductEntryHelperTest
    {
        public static ProductEntry CreateProductEntryExisting()
        {
            var productRepository = new ProductRepository();
            var product = productRepository.GetAll().First();

            var items = new List<ProductEntryItem>();
            var productEntry = new ProductEntry
            {
                Code = "CODE_1",
                Date = DateTime.Now,
                Supplier = new Supplier { ID = 1, Name = "FORNECEDOR_1" },
                Product = product,
                ProductEntryItems = null
            };
            items.Add(new ProductEntryItem { Quantity = 2, Variation = product.Variations[0], ProductEntry = productEntry });

            return productEntry;
        }

        public static ProductEntry CreateProductEntryValid()
        {
            var productRepository = new ProductRepository();
            var product = productRepository.GetAll().First();

            var items = new List<ProductEntryItem>();
            var productEntry = new ProductEntry
            {
                Code = "CODE_2",
                Date = DateTime.Now,
                Supplier = new Supplier { ID = 1, Name = "FORNECEDOR_1" },
                Product = product,
                ProductEntryItems = items
            };

            items.Add(new ProductEntryItem { Quantity = 2, Variation = product.Variations[0], ProductEntry = productEntry });

            return productEntry;
        }
    }
}
