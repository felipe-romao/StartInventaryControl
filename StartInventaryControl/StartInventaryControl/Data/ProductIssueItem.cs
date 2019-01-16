namespace StartInventaryControl.Data
{
    public class ProductIssueItem
    {
        public virtual long ID
        {
            get; set;
        }

        public virtual int Quantity
        {
            get; set;
        }

        public virtual Variation Variation
        {
            get; set;
        }

        public virtual ProductIssue ProductIssue
        {
            get; set;
        }

    }
}
