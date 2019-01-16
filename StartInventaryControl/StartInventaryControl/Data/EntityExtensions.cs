using StartInventaryControl.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartInventaryControl.Data
{
    public static class EntityExtensions
    {
        public static void Valid(this ProductIssue productIssue)
        {
            if(productIssue == null)
            {
                throw new ArgumentException($"Saida de produto não pode estar nula ou vazia.");
            }

            if (productIssue.Product == null)
            {
                throw new ArgumentException($"Saida de produto sem produto.");
            }
        }

        public static void Valid(this ProductEntry productEntry)
        {
            if (productEntry == null)
            {
                throw new ArgumentException($"Entrada de produto não pode estar nula ou vazia.");
            }

            if (productEntry.Supplier == null)
            {
                throw new ArgumentException($"Entrada de produto sem fornecedor.");
            }

            if (productEntry.Product == null )
            {
                throw new ArgumentException($"Entrada de produto sem produto.");
            }
        }

        public static IList<Variation> GetVariationUpdatedByProductEntryQuantity(this Product product, IList<ProductEntryItem> items)
        {
            if (product == null || items == null)
            {
                throw new Exception("Produto ou entrade de produtos não podem estar vazios.");
            }

            var variationsUpdated = new List<Variation>();
            foreach (var item in items)
            {
                if (item.Variation == null)
                {
                    throw new Exception("Variação não encontrada para ser atualizada.");
                }

                var variation = new Variation
                {
                    ID       = item.Variation.ID,
                    Color    = item.Variation.Color,
                    Gender   = item.Variation.Gender,
                    Product  = item.Variation.Product,
                    Size     = item.Variation.Size,
                    Quantity = item.Variation.Quantity + item.Quantity
                };
                variationsUpdated.Add(variation);
            }

            return variationsUpdated;
        }

        public static void CheckProductIssueQuantity(this Product product, ProductIssueItemDescriptor productIssueItemDescriptor)
        {
            var gender = productIssueItemDescriptor.Gender;
            var color = productIssueItemDescriptor.Color;
            var size = productIssueItemDescriptor.Size;
            var quantity = productIssueItemDescriptor.Quantity;
            var variation = product.GetProductVariation(gender, color, size);

            if (variation == null)
            {
                throw new Exception($"Variação {gender} / {color} / {size} não encontrada.");
            }

            if(variation.Quantity < quantity)
            {
                throw new Exception($"Saldo '{variation.Quantity}' da variação {gender} / {color} / {size} é insuficiente.");
            }
        }

        public static IList<Variation> GetVariationUpdatedByProductIssueQuantity(this Product product, IList<ProductIssueItem> items)
        {
            if (product == null || items == null)
            {
                throw new Exception("Produto ou saida de produtos não podem estar vazios.");
            }

            var variationsUpdated = new List<Variation>();
            foreach (var item in items)
            {
                if (item.Variation == null)
                {
                    throw new Exception("Variação não encontrada para ser atualizada.");
                }

                var variation = new Variation
                {
                    ID       = item.Variation.ID,
                    Color    = item.Variation.Color,
                    Gender   = item.Variation.Gender,
                    Product  = item.Variation.Product,
                    Size     = item.Variation.Size,
                    Quantity = item.Variation.Quantity - item.Quantity
                };
                variationsUpdated.Add(variation);
            }
            return variationsUpdated;
        }

        public static IList<string> GetAllGenders(this Product product)
        {
            var genders = new List<string>();

            if (product.Variations == null)
            {
                return genders;
            }

            foreach (var variation in product.Variations)
            {
                if (!genders.Contains(variation.Gender))
                    genders.Add(variation.Gender);
            }

            return genders;
        }

        public static IList<string> GetAllColorsByGender(this Product product, string gender)
        {
            var colors = new List<string>();
            if (string.IsNullOrEmpty(gender))
            {
                return colors;
            }

            if (product.Variations == null)
            {
                return colors;
            }

            foreach (var variation in product.Variations)
            {
                if (variation.Gender.Equals(gender))
                {
                    if (!colors.Contains(variation.Color))
                        colors.Add(variation.Color);
                }
            }

            return colors;
        }

        public static IList<string> GetAllSizesByGenderAndColor(this Product product, string gender, string color)
        {
            var sizes = new List<string>();
            if (string.IsNullOrEmpty(gender) || string.IsNullOrEmpty(color))
            {
                return sizes;
            }

            if (product.Variations == null)
            {
                return sizes;
            }

            foreach (var variation in product.Variations)
            {
                if (variation.Gender.Equals(gender) && variation.Color.Equals(color))
                {
                    sizes.Add(variation.Size);
                }
            }

            return sizes;
        }

        public static Variation GetProductVariation(this Product product, string gender, string color, string size)
        {
            if(product == null)
            {
                return null;
            }

            foreach (var variation in product.Variations)
            {
                if(variation.Color.Equals(color) && variation.Gender.Equals(gender) && variation.Size.Equals(size))
                {
                    return variation;
                }
            }

            return null;
        }

        public static IList<ProdutEntryDescriptor> GetProductEntriesDescriptor(this ProductEntry productEntry)
        {
            var list = new List<ProdutEntryDescriptor>();
            productEntry.Valid();

            foreach(var item in productEntry.ProductEntryItems)
            {
                var descriptor = new ProdutEntryDescriptor
                {
                    Date                 = productEntry.Date,
                    Supplier             = productEntry.Supplier.Name,
                    ProductName          = productEntry.Product.Description,
                    ProductColor         = item.Variation.Color,
                    ProductGender        = item.Variation.Gender,
                    ProductSize          = item.Variation.Size,
                    ProductQuantity      = item.Variation.Quantity,
                    ProductEntryQuantity = item.Quantity,
                };
                list.Add(descriptor);
            }
            return list;
        }

        public static IList<ProdutIssueDescriptor> GetProductIssuesDescriptor(this ProductIssue productIssue)
        {
            var list = new List<ProdutIssueDescriptor>();
            productIssue.Valid();

            foreach (var item in productIssue.ProductIssueItems)
            {
                var descriptor = new ProdutIssueDescriptor
                {
                    Date                 = productIssue.Date,
                    ProductName          = productIssue.Product.Description,
                    ProductColor         = item.Variation.Color,
                    ProductGender        = item.Variation.Gender,
                    ProductSize          = item.Variation.Size,
                    ProductQuantity      = item.Variation.Quantity,
                    ProductIssueQuantity = item.Quantity,
                };
                list.Add(descriptor);
            }
            return list;
        }

        public static IList<Variation> CreateVariations(this Product product, IList<string> genders, IList<string> colors, IList<string> sizes)
        {
            if(genders == null || genders.Count == 0)
            {
                throw new Exception("Nenhum genero cadastrado.");
            }
            if (colors == null || colors.Count == 0)
            {
                throw new Exception("Nenhuma cor cadastrado.");
            }
            if (sizes == null || sizes.Count == 0)
            {
                throw new Exception("Nenhum tamanho cadastrado.");
            }

            var variations = new List<Variation>();

            foreach(var gender in genders)
            {
                foreach (var color in colors)
                {
                    foreach (var size in sizes)
                    {
                        variations.Add(new Variation
                        {
                            Gender   = gender,
                            Color    = color,
                            Size     = size,
                            Quantity = 0,
                            Product  = product
                        });
                    }
                }
            }
            return variations;
        }

        public static void AddVariationsNoExists(this Product product, IList<string> genders, IList<string> colors, IList<string> sizes)
        {
            foreach (var gender in genders)
            {
                foreach (var color in colors)
                {
                    foreach (var size in sizes)
                    {
                        if (!product.HasSpecificVariaton(gender, color, size))
                        {
                            product.Variations.Add(new Variation
                            {
                                Gender   = gender,
                                Color    = color,
                                Size     = size,
                                Quantity = 0,
                                Product  = product
                            });
                        }
                    }
                }
            }
        }

        public static void UpdateAllVariationsStatic(IList<VariationType> variationTypes)
        {
            var genders = new List<string>();
            var colors  = new List<string>();
            var sizes   = new List<string>();

            foreach(var variationType in variationTypes)
            {
                if (variationType.Type.Equals(VariationType.GENDER))
                {
                    genders.Add(variationType.Value);
                    continue;
                }
                if (variationType.Type.Equals(VariationType.COLOR))
                {
                    colors.Add(variationType.Value);
                    continue;
                }
                if (variationType.Type.Equals(VariationType.SIZE))
                {
                    sizes.Add(variationType.Value);
                    continue;
                }

            }

            DataHelpers.Genders = genders;
            DataHelpers.Colors  = colors;
            DataHelpers.Sizes   = sizes;
        }
    }
}
