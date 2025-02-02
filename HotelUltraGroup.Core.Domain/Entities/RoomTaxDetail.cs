using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelUltraGroup.Core.Domain.Entities
{
    public class RoomTaxDetail
    {
        public int idRoom { get; private set; }
        public int idTax { get; private set; }

        public RoomTaxDetail(int idRoom, int idTax)
        {
            this.idRoom = idRoom;
            this.idTax = idTax;
        }
    }

}
