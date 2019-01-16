using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartInventaryControl.Data
{
    public class Supplier
    {
        public virtual long ID
        {
            get; set;
        }

        public virtual string Name
        {
            get; set;
        }

        public override string ToString() => this.Name;

        public virtual bool IsNew => this.ID > 0 ? false : true;
    }
}
