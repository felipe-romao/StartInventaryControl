namespace StartInventaryControl.Data
{
    public class Variation
    {
        public virtual long ID
        {
            get; set;
        }

        public virtual string Gender
        {
            get; set;
        }

        public virtual string Color
        {
            get; set;
        }

        public virtual string Size
        {
            get; set;
        }

        public virtual int Quantity
        {
            get; set;
        }

        public virtual Product Product
        {
            get; set;
        }
    }
}
