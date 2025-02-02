using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelUltraGroup.Core.Application.DTOs
{
    public class ListHotelDTO
    {
        public int idHotel { get; set; }
        public string name { get; set; }
        public int idCity { get; set; }
        public string nameCity { get; set; }
        public string address { get; set; }
        public bool isAvailable { get; set; }
    }
}
