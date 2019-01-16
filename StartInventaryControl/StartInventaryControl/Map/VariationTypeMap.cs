using FluentNHibernate.Mapping;
using StartInventaryControl.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartInventaryControl.Map
{
    public class VariationTypeMap: ClassMap<VariationType>
    {
        public VariationTypeMap()
        {
            Id(x => x.VariationTypeID);
            Map(x => x.Type);
            Map(x => x.Value);
            Table("VariationType");
        }
    }
}
