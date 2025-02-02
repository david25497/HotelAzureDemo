using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelUltraGroup.Core.Domain.ValueObjets
{
    public class Password
    {
        public string Value { get; }

        public Password(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length < 6)
                throw new ArgumentException("La contraseña debe tener al menos 6 caracteres.", "Error_Reglas");

            Value = value;
        }

        public override string ToString() => Value;
    }
}
