using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.Security.Dtos
{
    public class LoginDto
    {
        public LoginDto()
        {
            Errores = new List<string>();
        }

        [Required]
        [Display(Name = @"Usuario:")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = @"Contraseña:")]
        public string Password { get; set; }

        [Display(Name = @"Recordar?")]
        public bool RememberMe { get; set; }

        public List<string> Errores { get; set; } 
    }
}
