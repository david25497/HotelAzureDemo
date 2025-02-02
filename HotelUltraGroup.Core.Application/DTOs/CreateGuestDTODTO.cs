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
    public class CreateGuestDTO
    {
        [Required(ErrorMessage = "reservationCode es obligatorio.")]
        public string reservationCode { get; set; }

        [Required(ErrorMessage = "firstName es obligatorio.")]
        public string firstName { get; set; }

        [Required(ErrorMessage = "lastName es obligatorio.")]
        public string lastName { get; set; }

        [Required(ErrorMessage = "idGender es obligatorio.")]
        public int idGender { get; set; }

        [Required(ErrorMessage = "idDocumentType es obligatorio.")]
        public int idDocumentType { get; set; }

        [Required(ErrorMessage = "documentNumber es obligatorio.")]
        public string documentNumber { get; set; }

        [Required(ErrorMessage = "email es obligatorio.")]
        public string email { get; set; }

        [Required(ErrorMessage = "phone es obligatorio.")]
        public string phone { get; set; }
    }
}
