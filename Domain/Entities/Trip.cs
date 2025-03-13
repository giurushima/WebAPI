using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class Trip
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Ingrese origen de viaje (mayor a 5 caracteres)")]
        [MinLength(5)]
        public string? Source { get; set; }
        [Required(ErrorMessage = "Ingrese destino de viaje (mayor a 5 caracteres)")]
        [MinLength(5)]
        public string? Destiny { get; set; }
        [Required(ErrorMessage = "Ingrese kilometros del viaje")]
        public int Kilometers { get; set; }
        [Required(ErrorMessage = "Ingrese descripcion de viaje (menor a 100 caracteres)")]
        [MaxLength(100)]
        public string? Description { get; set; }
        [ForeignKey("TruckerId")]
        public Trucker? Trucker { get; set; }
        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TripStatus TripStatus { get; set; }
        public int TruckerId { get; set; }
    }
}
