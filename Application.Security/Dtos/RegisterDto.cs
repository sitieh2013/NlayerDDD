using System.ComponentModel.DataAnnotations;

namespace Application.Security.Dtos
{
    public class RegisterDto
    {
        [Required]
        [Display(Name = @"Usuario")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "La {0} no puede ser menor de {2} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = @"Contraseña")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = @"Confirmar contraseña")]
        [Compare("Password", ErrorMessage = @"Las contraseñas no coinciden.")]
        public string ConfirmPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = @"Rol")]
        public string Rol { get; set; }
    }
}
