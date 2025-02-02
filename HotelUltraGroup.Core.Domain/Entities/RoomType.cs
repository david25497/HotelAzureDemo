using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelUltraGroup.Core.Domain.Entities
{
    public class RoomType
    {
        public int roomTypeId { get; private set; }
        public string name { get; private set; }
        public string description { get; private set; }

        public RoomType(string name, string description)
        {
            this.name = string.IsNullOrWhiteSpace(name)
                   ? throw new ArgumentException("Tipo de habitación es requerida.", "Error_Reglas") : name;
            this.description = description ?? throw new ArgumentException("Descripcion es requerida", "Error_Reglas");
        }
    }

}
