using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartInventaryControl.Data
{
    public class WorkOrderProduct
    {
        public virtual long ID
        {
            get; set;
        }

        public virtual Product Product
        {
            get; set;
        }

        public virtual int Quantity
        {
            get; set;
        }

        public virtual WorkOrder WorkOrder
        {
            get; set;
        }
    }
}
