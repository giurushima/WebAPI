using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Domain.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Ingrese nombre (menor a 32 caracteres)")]
        [MaxLength(32)]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Ingrese nombre de usuario (menor a 15 caracteres)")]
        [MaxLength(15)]
        public string? UserName { get; set; }
        [Required(ErrorMessage = "Ingrese contraseña (mayor a 4 caracteres)")]
        [MinLength(4)]
        public string? Password { get; set; }
        [Required(ErrorMessage = "Ingrese rol")]
        public Roles Roles { get; set; }
    }
}
