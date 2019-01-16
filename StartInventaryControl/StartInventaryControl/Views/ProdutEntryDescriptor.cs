using StartInventaryControl.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartInventaryControl.Views
{
    public class ProdutEntryDescriptor
    {
        public DateTime Date { get; set; }
        public string Supplier { get; set; }
        public string ProductName { get; set; }
        public string ProductGender { get; set; }
        public string ProductColor { get; set; }
        public string ProductSize { get; set; }
        public int ProductQuantity { get; set; }
        public int ProductEntryQuantity { get; set; }
    }
}

