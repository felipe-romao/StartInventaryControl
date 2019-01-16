using System;
using System.Collections.Generic;

namespace StartInventaryControl.Data
{
    public class ProductIssue
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

        public virtual Product Product
        {
            get; set;
        }

        public virtual IList<ProductIssueItem> ProductIssueItems
        {
            get; set;
        }
    }
}
