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
    public class CreateReservationDTO
    {
        [Required(ErrorMessage = "idHotel es obligatorio.")]
        public int idHotel { get; set; }

        [Required(ErrorMessage = "idRoom es obligatorio.")]
        public int idRoom { get; set; }

        [Required(ErrorMessage = "checkInDate es obligatorio.")]
        public DateTime checkInDate { get; set; }

        [Required(ErrorMessage = "checkOutDate es obligatorio.")]
        public DateTime checkOutDate { get; set; }

        [Required(ErrorMessage = "fullName es obligatorio.")]
        public string fullName { get; set; }

        [Required(ErrorMessage = "reservationEmail es obligatorio.")]
        public string reservationEmail { get; set; }

        [Required(ErrorMessage = "emergencyContactName es obligatorio.")]
        public string emergencyContactName { get; set; }

        [Required(ErrorMessage = "emergencyContactPhone es obligatorio.")]
        public string emergencyContactPhone { get; set; }


    }
}
