using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelUltraGroup.Core.Domain.Stored_Procedure
{
    public class sp_GetAvailableHotels
    {
        public int HotelId { get; set; }          // ID del hotel
        public string HotelName { get; set; }      // Nombre del hotel
        public int IdCity { get; set; }            // ID de la ciudad
        public string Address { get; set; }        // Dirección del hotel
    }
}
