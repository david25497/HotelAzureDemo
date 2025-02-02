using HotelUltraGroup.Core.Domain.ValueObjets;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HotelUltraGroup.Core.Domain.Entities
{
    public class Tax
    {
        public int idTax { get; private set; }
        public int idHotel { get; private set; }
        public string name { get; private set; }
        public Rate rate { get; private set; } // Value Object para el campo rate
        public string description { get; private set; }
        public Tax(int idHotel, string name, Rate rate, string description)
        {
            this.idHotel = idHotel;
            this.name = string.IsNullOrWhiteSpace(name)
                       ? throw new ArgumentException("name es requerida.", "Error_Reglas") : name;
            this.rate = rate ?? throw new ArgumentException("rate requerida.", "Error_Reglas");
            this.description = string.IsNullOrWhiteSpace(description)
                       ? throw new ArgumentException("description es requerida.", "Error_Reglas") : description;
        }

        public Tax(int idTax, int idHotel, string name, Rate rate, string description)
        {
            this.idTax = idTax;
            this.idHotel = idHotel;
            this.name = string.IsNullOrWhiteSpace(name)
                       ? throw new ArgumentException("name es requerida.", "Error_Reglas") : name;
            this.rate = rate ?? throw new ArgumentException("rate requerida.", "Error_Reglas");
            this.description = string.IsNullOrWhiteSpace(description)
                       ? throw new ArgumentException("description es requerida.", "Error_Reglas") : description;
        }



    }

}
