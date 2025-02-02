using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelUltraGroup.Core.Application.DTOs
{
    public class CreateHotelDTO
    {
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string name { get; set; }

        [Required(ErrorMessage = "La ciudad es obligatoria.")]
        public int idCity { get; set; }

        [Required(ErrorMessage = "La dirección es obligatoria.")]
        public string address { get; set; }
    }
}
