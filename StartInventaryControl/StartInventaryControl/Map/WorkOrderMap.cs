using FluentNHibernate.Mapping;
using StartInventaryControl.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartInventaryControl.Map
{
    public class WorkOrderMap : ClassMap<WorkOrder>
    {
        public WorkOrderMap()
        {
            Id(c => c.ID);
            Map(c => c.Code);
            Map(c => c.Date);
            Map(c => c.Annotation);
            References(c => c.Supplier, "SupplierID").Not.LazyLoad();
            HasMany(c => c.WorkOrderProduct).Cascade.All().Inverse().KeyColumn("WorkOrderID").Not.LazyLoad();
            Table("WorkOrder");
        }
    }
}
