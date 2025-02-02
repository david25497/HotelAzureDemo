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
    public class CreateRoomDTO
    {
        [Required(ErrorMessage = "IdHotel es obligatorio.")]
        public int idHotel { get; set; }

        [Required(ErrorMessage = "name es obligatorio.")]
        public string name { get; set; }

        [Required(ErrorMessage = "idRoomType es obligatorio.")]
        public int idRoomType { get; set; }
        
        [Required(ErrorMessage = "location es obligatorio.")]
        public string location { get; set; }

        [Required(ErrorMessage = "nightlyRate es obligatorio.")]
        public decimal nightlyRate { get; set; }

        [Required(ErrorMessage = "isAvailable es obligatorio.")]
        public bool isAvailable { get; set; }

        [Required(ErrorMessage = "capacity es obligatorio.")]
        public int capacity { get; set; }


    }
}
