using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class Trucker
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Ingrese nombre completo (menor a 32 caracteres)")]
        [MaxLength(32)]
        public string? CompleteName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Ingrese tipo de carga (menor a 32 caracteres)")]
        [MaxLength(32)]
        public string? TruckerType { get; set; }
        [JsonIgnore]
        public ICollection<Trip> Trips { get; set; } = new List<Trip>();
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Roles Roles { get; set; }
    }
}
