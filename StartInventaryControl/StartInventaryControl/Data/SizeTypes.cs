using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartInventaryControl.Data
{
    public sealed class SizeTypes
    {
        public static SizeTypes FromValue(string value)
        {
            if (PP.Value.Equals(value))
                return PP;

            if (P.Value.Equals(value))
                return P;

            if (M.Value.Equals(value))
                return M;

            if (G.Value.Equals(value))
                return G;

            if (GG.Value.Equals(value))
                return GG;

            if (XGG.Value.Equals(value))
                return XGG;

            throw new ArgumentException($"Tamanho '{value}' não encontrado.");
        }

        public static readonly SizeTypes PP = new SizeTypes("PP");
        public static readonly SizeTypes P = new SizeTypes("P");
        public static readonly SizeTypes M = new SizeTypes("M");
        public static readonly SizeTypes G = new SizeTypes("G");
        public static readonly SizeTypes GG = new SizeTypes("GG");
        public static readonly SizeTypes XGG = new SizeTypes("XGG");

        private SizeTypes(string value)
        {
            this.Value = value;
        }

        public string Value
        {
            get;
        }

        public override string ToString()
        {
            return this.Value;
        }

        public static string SizeDescription()
        {
            return "TAMANHO";
        }
    }
}
