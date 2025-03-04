using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Auth
{
    public class AuthenticationRequestBody
    {
        [Required(ErrorMessage = "Ingrese nombre de usuario (menor a 15 caracteres)")]
        [MaxLength(15)]
        public string? UserName { get; set; }
        [Required(ErrorMessage = "Ingrese contraseña (mayor a 4 caracteres)")]
        [MinLength(4)]
        public string? Password { get; set; }
    }
}
