namespace StartInventaryControl.Data
{
    public class ProductEntryItem
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

        public virtual ProductEntry ProductEntry
        {
            get; set;
        }
    }
}
