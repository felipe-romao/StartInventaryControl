using NUnit.Framework;
using StartInventaryControl.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartInventaryControl.UnitTest.Data
{
    [TestFixture]
    public class ProductTest
    {
        //[Test]
        //public void GetDescription_ProductAttributesIsEmpty_DescriptionIsEmpty()
        //{
        //    var product = new Product();

        //    Assert.That(product.Description, Is.EqualTo(string.Empty)); 
        //}

        //[Test]
        //public void GetDescription_ModelIsInvalid_DescriptionWithoutModelInfo()
        //{
        //    var product1 = new Product
        //    {
        //        ID      = 1,
        //        Color   = new Color { ID = 1, Name = "AZUL" },
        //        Size    = SizeTypes.M.ToString(),
        //        Gender  = GenderTypes.MASCULINO.ToString(),
        //    };

        //    var product2 = new Product
        //    {
        //        ID      = 1,
        //        Color   = new Color { ID = 1, Name = "AZUL" },
        //        Model   = new Model(),
        //        Size    = SizeTypes.M.ToString(),
        //        Gender  = GenderTypes.MASCULINO.ToString(),
        //    };

        //    Assert.That(product1.Description, Is.EqualTo("MASCULINO - AZUL - TAMANHO M"));
        //    Assert.That(product2.Description, Is.EqualTo("MASCULINO - AZUL - TAMANHO M"));
        //}

        //[Test]
        //public void GetDescription_GenderIsInvalid_DescriptionWithoutGenderInfo()
        //{
        //    var product = new Product
        //    {
        //        ID      = 1,
        //        Model   = new Model { ID = 1, Name = "CAMISA TRADICIONAL" },
        //        Color   = new Color { ID = 1, Name = "AZUL" },
        //        Size    = SizeTypes.M.ToString(),
        //    };

        //    Assert.That(product.Description, Is.EqualTo("CAMISA TRADICIONAL - AZUL - TAMANHO M"));
        //}

        //[Test]
        //public void GetDescription_ColorIsInvalid_DescriptionWithoutColorInfo()
        //{
        //    var product1 = new Product
        //    {
        //        ID      = 1,
        //        Model   = new Model { ID = 1, Name = "CAMISA TRADICIONAL" },
        //        Gender  = GenderTypes.MASCULINO.ToString(),
        //        Size    = SizeTypes.M.ToString(),
        //    };

        //    var product2 = new Product
        //    {
        //        ID      = 1,
        //        Model   = new Model { ID = 1, Name = "CAMISA TRADICIONAL" },
        //        Gender  = GenderTypes.MASCULINO.ToString(),
        //        Size    = SizeTypes.M.ToString(),
        //    };

        //    Assert.That(product1.Description, Is.EqualTo("CAMISA TRADICIONAL - MASCULINO - TAMANHO M"));
        //    Assert.That(product2.Description, Is.EqualTo("CAMISA TRADICIONAL - MASCULINO - TAMANHO M"));
        //}

        //[Test]
        //public void GetDescription_SizeIsInvalid_DescriptionWithoutSizeInfo()
        //{
        //    var product = new Product
        //    {
        //        ID      = 1,
        //        Model   = new Model { ID = 1, Name = "CAMISA TRADICIONAL" },
        //        Gender  = GenderTypes.MASCULINO.ToString(),
        //        Color   = new Color { ID = 1, Name = "AZUL" },
        //    };

        //    Assert.That(product.Description, Is.EqualTo("CAMISA TRADICIONAL - MASCULINO - AZUL"));
        //}

        //[Test]
        //public void GetDescription_AllAttributesIsValid_DescriptionGeneratedCorrect()
        //{
        //    var product = new Product
        //    {
        //        ID      = 1,
        //        Model   = new Model { ID = 1, Name = "CAMISA TRADICIONAL" },
        //        Gender  = GenderTypes.MASCULINO.ToString(),
        //        Color   = new Color { ID = 1, Name = "AZUL" },
        //        Size    = SizeTypes.M.ToString(),
        //    };

        //    Assert.That(product.Description, Is.EqualTo("CAMISA TRADICIONAL - MASCULINO - AZUL - TAMANHO M"));
        //}
    }
}
