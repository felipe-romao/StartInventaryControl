using FluentNHibernate.Mapping;
using StartInventaryControl.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartInventaryControl.Map
{
    public class ProductIssueMap : ClassMap<ProductIssue>
    {
        public ProductIssueMap()
        {
            Id(c => c.ID);
            Map(c => c.Code);
            Map(c => c.Date);
            Map(c => c.Annotation);
            References(c => c.Product, "ProductID").Not.LazyLoad();
            HasMany(c => c.ProductIssueItems).Cascade.All().Inverse().KeyColumn("ProductIssueID").Not.LazyLoad();
            Table("ProductIssue");
        }
    }
}
