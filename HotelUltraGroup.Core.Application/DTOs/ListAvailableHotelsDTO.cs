using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelUltraGroup.Core.Application.DTOs
{
    public class ListAvailableHotelsDTO
    {
        public int HotelId { get; set; } 
        public string HotelName { get; set; }  
        public int IdCity { get; set; } 
        public string Address { get; set; }  
    }
}
