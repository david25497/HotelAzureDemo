using HotelUltraGroup.Core.Domain.Entities;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelUltraGroup.Core.Application.DTOs
{
    public class UpdateRoomDTO
    {
        [Required(ErrorMessage = "IdHotel es obligatorio.")]
        public int idHotel { get; set; }

        [Required(ErrorMessage = "idRoom es obligatorio.")]
        public int idRoom { get; set; }

        [Required(ErrorMessage = "name es obligatorio.")]
        public string name { get; set; }

        [Required(ErrorMessage = "idRoomType es obligatorio.")]
        public int idRoomType { get; set; }
        
        [Required(ErrorMessage = "location es obligatorio.")]
        public string location { get; set; }

        [Required(ErrorMessage = "nightlyRate es obligatorio.")]
        public decimal nightlyRate { get; set; }

        [Required(ErrorMessage = "capacity es obligatorio.")]
        public int capacity { get; set; }


    }
}
