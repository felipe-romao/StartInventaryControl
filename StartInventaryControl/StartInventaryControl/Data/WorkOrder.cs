using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartInventaryControl.Data
{
    public class WorkOrder
    {
        public virtual long ID
        {
            get; set;
        }

        public virtual string Code
        {
            get; set;
        }

        public virtual DateTime Date
        {
            get; set;
        }

        public virtual string Annotation
        {
            get; set;
        }

        public virtual Supplier Supplier
        {
            get; set;
        }

        public virtual IList<WorkOrderProduct> WorkOrderProduct
        {
            get; set;
        }
    }
}
