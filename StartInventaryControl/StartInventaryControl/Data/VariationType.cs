using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartInventaryControl.Data
{
    public class VariationType
    {
        public readonly static string GENDER = "GENERO";
        public readonly static string COLOR  = "COR";
        public readonly static string SIZE   = "TAMANHO";
        public readonly static List<string> TYPES = new List<string>{ GENDER, COLOR, SIZE };

        public virtual long VariationTypeID { get; set; }
        public virtual string Type { get; set; }
        public virtual string Value { get; set; }
    }
}
