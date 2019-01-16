namespace StartInventaryControl.Data
{
    public class ProductQuantityResult
    {
        public Variation Variation { get; set; }

        public bool IsValid { get; set; }

        public string ErrorMessage { get; set; }
    }
}
