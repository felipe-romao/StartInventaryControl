using FluentNHibernate.Mapping;
using StartInventaryControl.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartInventaryControl.Map
{
    public class VariationMap : ClassMap<Variation>
    {
        public VariationMap()
        {
            Id(c => c.ID);
            Map(c => c.Gender);
            Map(c => c.Color);
            Map(c => c.Size);
            Map(c => c.Quantity);
            References(c => c.Product, "ProductID").Not.LazyLoad();
            Table("Variation");
        }
    }
}
