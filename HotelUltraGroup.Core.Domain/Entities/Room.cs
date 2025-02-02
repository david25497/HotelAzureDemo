using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelUltraGroup.Core.Domain.Entities
{
    public class Room
    {
        public int idRoom { get; private set; }
        public int idHotel { get; private set; }
        public string name { get; private set; }
        public int idRoomType { get; private set; }
        public decimal nightlyRate { get; private set; }
        public bool isAvailable { get; private set; }
        public int capacity { get; private set; }
        public string location { get; private set; }

        public Room(int idHotel, string name, int idRoomType, decimal nightlyRate, int capacity, string location)
        {
            this.idHotel = idHotel;
            this.name = string.IsNullOrWhiteSpace(name)
                   ? throw new ArgumentException("Nombre de habitación es requerido.", "Error_Reglas") : name;
            this.idRoomType = idRoomType;
            this.nightlyRate = nightlyRate > 0 ? nightlyRate : throw new ArgumentException("Valor debe ser positivo.", "Error_Reglas");
            isAvailable = true; 
            this.capacity = capacity > 0 ? capacity : throw new ArgumentException("Capacidad debe ser positivo.", "Error_Reglas");
            this.location = location ?? throw new ArgumentException("Ubicación es requerido.", "Error_Reglas");
        }

        public Room(int idRoom ,int idHotel, string name, int idRoomType, decimal nightlyRate, int capacity, string location)
        {
            this.idRoom = idRoom;
            this.idHotel = idHotel;
            this.name = string.IsNullOrWhiteSpace(name)
                   ? throw new ArgumentException("Nombre de habitación es requerido.", "Error_Reglas") : name;
            this.idRoomType = idRoomType;
            this.nightlyRate = nightlyRate > 0 ? nightlyRate : throw new ArgumentException("Valor debe ser positivo.", "Error_Reglas");
            isAvailable = true;
            this.capacity = capacity > 0 ? capacity : throw new ArgumentException("Capacidad debe ser positivo.", "Error_Reglas");
            this.location = location ?? throw new ArgumentException("Ubicación es requerido.", "Error_Reglas");
        }

        public Room(int idRoom, int idHotel, bool isAvailable)
        {
            this.idRoom = idRoom;
            this.idHotel = idHotel;
            this.isAvailable = isAvailable;
        }


    }

}
