using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartInventaryControl.Data
{
    public sealed class GenderTypes
    {
        public static GenderTypes FromValue(string value)
        {
            if (MASCULINO.Value.Equals(value))
                return MASCULINO;

            if (MASCULINO.Value.Equals(value))
                return MASCULINO;

            throw new ArgumentException($"Gênero '{value}' não encontrado.");
        }

        public static readonly GenderTypes MASCULINO = new GenderTypes("MASCULINO");
        public static readonly GenderTypes FEMININO = new GenderTypes("FEMININO");

        private GenderTypes(string value)
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
    }
}
