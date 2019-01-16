using FluentNHibernate.Mapping;
using StartInventaryControl.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartInventaryControl.Map
{
    public class ProducEntryMap : ClassMap<ProductEntry>
    {
        public ProducEntryMap()
        {
            Id(c => c.ID);
            Map(c => c.Code);
            Map(c => c.Date);
            Map(c => c.Annotation);
            References(c => c.Supplier, "SupplierID").Not.LazyLoad();
            References(c => c.Product, "ProductID").Not.LazyLoad();
            HasMany(c => c.ProductEntryItems).Cascade.All().KeyColumn("ProductEntryID").Not.LazyLoad();
            Table("ProductEntry");
        }
    }
}
