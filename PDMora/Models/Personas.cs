using System;
using PDMora.Models.Validaciones;
using System.ComponentModel.DataAnnotations;

namespace PDMora.Models
{
    public class Personas
    {
        [Key]
        public int PersonaId { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string Nombres { get; set; }

        [CedulaV]
        public string Cedula { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public DateTime FechaNacimiento { get; set; } = DateTime.Now;

        public double Balance { get; set; }
        
    }
}