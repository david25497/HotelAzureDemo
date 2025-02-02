using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelUltraGroup.Core.Application.DTOs
{
    public class CreateUserDTO
    {
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string username { get; set; }

        [Required(ErrorMessage = "El email es obligatorio.")]
        public string email { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatorio.")]
        public string password { get; set; }
    }
}
