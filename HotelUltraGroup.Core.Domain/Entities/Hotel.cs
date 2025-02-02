using HotelUltraGroup.Core.Domain.ValueObjets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelUltraGroup.Core.Domain.Entities
{
    public class Hotel
    {
        public int idUser { get; private set; }
        public int idHotel { get; private set; }
        public string name { get; private set; }
        public int idCity { get; set; } 
        public string address { get; private set; }
        public bool isAvailable { get; private set; }


        public Hotel(int idUser, string name, int idCity, string address)
        {
            this.idUser = idUser;
            this.name = string.IsNullOrWhiteSpace(name)
                       ? throw new ArgumentException("El nombre es requerido.", "Error_Reglas") : name;
            this.idCity = idCity;
            this.address = string.IsNullOrWhiteSpace(address)
                       ? throw new ArgumentException("La dirección es requerida.", "Error_Reglas") : address;
        }

        public Hotel(int idUser, int idHotel, string name, int idCity, string address)
        {
            this.idUser = idUser;
            this.idHotel = idHotel;
            this.name = string.IsNullOrWhiteSpace(name)
                       ? throw new ArgumentException("El nombre es requerido.", "Error_Reglas") : name;
            this.idCity = idCity;
            this.address = string.IsNullOrWhiteSpace(address)
                       ? throw new ArgumentException("La dirección es requerida.", "Error_Reglas") : address;
        }
        public Hotel(int idUser, int idHotel, bool isAvailable)
        {
            this.idUser = idUser;
            this.idHotel = idHotel;
            this.isAvailable =  isAvailable ;
        }


    }
}
