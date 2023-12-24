using System.ComponentModel.DataAnnotations;

namespace Pagos.Models
{
    public class Usuario
    {
        [Key]
        public string? UsuarioIdentificacion { get; set; }
        public string? UsuarioNombre { get; set; }
        public string? UsuarioEmail { get; set; }
    }
}
