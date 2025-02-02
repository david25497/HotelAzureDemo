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
    public class RoomTaxAssignmentDTO
    {
        [Required(ErrorMessage = "IdRoom es obligatorio.")]
        public int idRoom { get; set; }

        [Required(ErrorMessage = "IdTax es obligatorio.")]
        public int idTax { get; set; }

        [Required(ErrorMessage = "IdHotel es obligatorio.")]
        public int idHotel { get; set; }

    }
}
