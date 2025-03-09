using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Trip
{
    public class CreateTripDto
    {
        [Required(ErrorMessage = "Ingrese origen de viaje (mayor a 5 caracteres)")]
        [MinLength(5)]
        public string? Source { get; set; }
        [Required(ErrorMessage = "Ingrese destino de viaje (mayor a 5 caracteres)")]
        [MinLength(5)]
        public string? Destiny { get; set; }
        [Required(ErrorMessage = "Ingrese descripcion de viaje (menor a 100 caracteres)")]
        [MaxLength(100)]
        public string? Description { get; set; }
        [Required]
        public TripStatus TripStatus { get; set; }
    }

    public class UpdateTripDto
    {
        [Required(ErrorMessage = "Ingrese origen de viaje (mayor a 5 caracteres)")]
        [MinLength(5)]
        public string? Source { get; set; }
        [Required(ErrorMessage = "Ingrese destino de viaje (mayor a 5 caracteres)")]
        [MinLength(5)]
        public string? Destiny { get; set; }
        [Required(ErrorMessage = "Ingrese descripcion de viaje (menor a 100 caracteres)")]
        [MaxLength(100)]
        public string? Description { get; set; }
        [Required]
        public TripStatus TripStatus { get; set; }
    }
}