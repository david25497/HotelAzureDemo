using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelUltraGroup.Core.Application.DTOs
{
    public class ListRoomWithRoomTypeDto
    {
        public int Id { get; set; }
        public string RoomName { get; set; }
        public decimal NightlyRate { get; set; }
        public bool IsAvailable { get; set; }
        public int Capacity { get; set; }
        public string Location { get; set; }
        public string RoomTypeName { get; set; }
    }
}
