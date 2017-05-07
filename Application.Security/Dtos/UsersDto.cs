using System.ComponentModel.DataAnnotations;

namespace Application.Security.Dtos
{
    public class UsersDto
    {
        [Required]
        [Display(Name = @"Usuario:")]
        public string UserName { get; set; }

        [Display(Name = @"Usuario Nuevo:")]
        public string UserNameNew { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = @"Contraseña:")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = @"Contraseña Nueva:")]
        public string PasswordNew { get; set; }

        [Display(Name = @"Habilitar")]
        public bool Enabled { get; set; }

        [Display(Name = @"Rol")]
        public string Rol { get; set; }

        [Display(Name = @"Rol Nuevo")]
        public string RolNew { get; set; }

    }
}
