using System.ComponentModel.DataAnnotations;

namespace HotelUltraGroup.Core.Application.DTOs
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string username { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatorio.")]
        public string password { get; set; }
    }
}
