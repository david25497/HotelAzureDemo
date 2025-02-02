using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HotelUltraGroup.Core.Domain.ValueObjets
{
    public class Email
    {
        public string Value { get; }

        public Email(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("El email no puede estar vacío.", "Error_Reglas");

            if (!IsValidEmail(value))
                throw new ArgumentException("El email no es válido.", "Error_Reglas");

            Value = value;
        }

        private bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        public override string ToString() => Value;
    }
}
