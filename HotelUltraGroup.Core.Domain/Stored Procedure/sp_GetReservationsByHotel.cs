using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelUltraGroup.Core.Domain.Stored_Procedure
{
    public class sp_GetReservationsByHotel
    {
        public int idReservation { get; set; }
        public string reservationCode { get; set; }
        public DateTime checkInDate { get; set; }
        public DateTime checkOutDate { get; set; }
        public string fullName { get; set; }
        public string reservationEmail { get; set; }
    }
}
