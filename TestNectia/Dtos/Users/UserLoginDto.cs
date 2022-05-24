using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FrutasApi.Dtos.Users
{
    public class UserLoginDto
    {
        [Required(ErrorMessage = "Nombre es un campo requerido")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Password es un campo requerido")]
        public string Password { get; set; }
    }
    public class PasswordValidDto
    {
        public string Name { get; set; }
        public bool IsAuthenticated { get; set; }
    }
}
