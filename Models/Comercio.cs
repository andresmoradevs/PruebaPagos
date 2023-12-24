using System.ComponentModel.DataAnnotations;

namespace Pagos.Models
{
    public class Comercio
    {
        [Key]
        public int ComercioCodigo { get; set; }
        public string? ComercioNombre { get; set; }
        public string? ComercioNit { get; set; }
        public string? ComercioDireccion { get; set; } 
    }
}
