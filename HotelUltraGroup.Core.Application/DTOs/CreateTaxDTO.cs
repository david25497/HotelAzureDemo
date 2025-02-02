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
    public class CreateTaxDTO
    {
        [Required(ErrorMessage = "idHotel es obligatorio.")]
        public int idHotel{ get; set; }

        [Required(ErrorMessage = "name es obligatoria.")]
        public string name { get; set; }

        [Required(ErrorMessage = "rate es obligatoria.")]
        public decimal rate { get; set; }

        [Required(ErrorMessage = "description es obligatoria.")]
        public string description{ get; set; }      

    }
}
