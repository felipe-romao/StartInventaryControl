using FluentNHibernate.Mapping;
using StartInventaryControl.Data;

namespace StartInventaryControl.Map
{
    public class SupplierMap : ClassMap<Supplier>
    {
        public SupplierMap()
        {
            Id(c => c.ID);
            Map(c => c.Name);
            Table("Supplier");
        }
    }
}
