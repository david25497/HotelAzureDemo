using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelUltraGroup.Core.Domain.Stored_Procedure
{
    public class sp_GetAvailableHotelRooms
    {
        public int idRoom { get; set; }           // ID de la habitación
        public string RoomName { get; set; }      // Nombre de la habitación
        public int Capacity { get; set; }         // Capacidad de la habitación
        public decimal NightlyRate { get; set; }  // Tarifa por noche
        public bool IsAvailable { get; set; }     // Disponibilidad de la habitación
    }

}
