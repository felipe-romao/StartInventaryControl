using FluentNHibernate.Mapping;
using StartInventaryControl.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartInventaryControl.Map
{
    public class WorkOrderProductMap : ClassMap<WorkOrderProduct>
    {
        public WorkOrderProductMap()
        {
            Id(c => c.ID);
            Map(c => c.Quantity);
            References(c => c.WorkOrder, "WorkOrderID").Not.LazyLoad();
            References(c => c.Product, "ProductID").Not.LazyLoad();
            Table("WorkOrderProduct");
        }
    }
}
