using StartInventaryControl.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartInventaryControl.Repository
{
    public interface IWorkOrderRepository
    {
        void Add(WorkOrder workOrder);

        WorkOrder GetByCode(string code);

        IList<WorkOrder> GetAll();

        void Update(WorkOrder workOrder);

        void Delete(WorkOrder workOrder);
    }
}
