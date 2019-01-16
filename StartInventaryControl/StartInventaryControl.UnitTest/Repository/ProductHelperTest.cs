using StartInventaryControl.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartInventaryControl.UnitTest.Repository
{
    public static class ProductHelperTest
    {
        public static Product CreateProductExisting()
        {
            var variations = new List<Variation>();
            var product = new Product
            {
                Description = "CAMISA",
                Variations = variations
            };

            variations.Add(new Variation { Gender = "MASCULINO", Color = "AZUL", Quantity = 1, Size = "M", Product = product });

            return product;
        }

        public static Product CreateProductValid()
        {
            var variations = new List<Variation>();
            var product = new Product
            {
                Description = "CAMISETA",
                Variations = variations
            };

            variations.Add(new Variation { Gender = "MASCULINO", Color = "AZUL", Quantity = 1, Size = "M", Product = product });
            variations.Add(new Variation { Gender = "MASCULINO", Color = "AZUL", Quantity = 1, Size = "G", Product = product });

            return product;
        }
    }
}
