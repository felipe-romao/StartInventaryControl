using FluentNHibernate.Mapping;
using StartInventaryControl.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartInventaryControl.Map
{
    public class ProductEntryItemMap : ClassMap<ProductEntryItem>
    {
        public ProductEntryItemMap()
        {
            Id(c => c.ID);
            Map(c => c.Quantity);
            References(c => c.ProductEntry, "ProductEntryID").Not.LazyLoad();
            References(c => c.Variation, "VariationID").Not.LazyLoad();
            Table("ProductEntryItem");
        }
    }
}
