
using System.ComponentModel.DataAnnotations;

namespace PDMora.Models
{
    public class MorasDetalle
    {
        [Key]
        public int Id { get; set; }
        public int MoraId { get; set; }
        public int PrestamoId { get; set; }
        public string NombrePersona { get; set; }
        public double Valor { get; set; }
    }
}