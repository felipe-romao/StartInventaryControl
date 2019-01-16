using FluentNHibernate.Mapping;
using NHibernate.Mapping;
using StartInventaryControl.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartInventaryControl.Map
{
    public class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            Id(c => c.ID);
            Map(c => c.Description);
            Map(c => c.Annotation);
            Map(c => c.ImagePath);
            HasMany(c => c.Variations).Cascade.All().Inverse().KeyColumn("ProductID").Not.LazyLoad();
            Table("Product");
        }
    }
}
