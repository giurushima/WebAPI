using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Truck
{
    public class TruckerDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ingrese nombre completo (menor a 32 caracteres)")]
        [MaxLength(32)]
        public string? CompleteName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Ingrese tipo de carga (menor a 32 caracteres)")]
        [MaxLength(32)]
        public string? TruckerType { get; set; }
    }
    public class CreateTruckDto
    {
        [Required(ErrorMessage = "Ingrese nombre completo (menor a 32 caracteres)")]
        [MaxLength(32)]
        public string? CompleteName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Ingrese tipo de carga (menor a 32 caracteres)")]
        [MaxLength(32)]
        public string? TruckerType { get; set; }
    }

    public class UpdateTruckDto
    {
        [Required(ErrorMessage = "Ingrese nombre completo (menor a 32 caracteres)")]
        [MaxLength(32)]
        public string? CompleteName { get; set; }
        [Required(ErrorMessage = "Ingrese tipo de carga (menor a 32 caracteres)")]
        [MaxLength(32)]
        public string? TruckerType { get; set; }
    }
}
