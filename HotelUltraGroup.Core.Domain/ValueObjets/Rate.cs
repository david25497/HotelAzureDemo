using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelUltraGroup.Core.Domain.ValueObjets
{
    public class Rate
    {
        public decimal Value { get; }

        public Rate(decimal value)
        {
            if (value < 0 || value > 100)
                throw new ArgumentException("Porcentaje debe ser entre 0 y 100.", "Error_Reglas");

            Value = value;
        }

        public override string ToString() => $"{Value}%";
    }
}
