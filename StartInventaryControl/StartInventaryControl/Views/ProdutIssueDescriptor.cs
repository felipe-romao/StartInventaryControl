using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartInventaryControl.Views
{
    public class ProdutIssueDescriptor
    {
        public DateTime Date { get; set; }
        public string ProductName { get; set; }
        public string ProductGender { get; set; }
        public string ProductColor { get; set; }
        public string ProductSize { get; set; }
        public int ProductQuantity { get; set; }
        public int ProductIssueQuantity { get; set; }
    }
}
