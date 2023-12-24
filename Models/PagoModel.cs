


using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Pagos.Models
{
    public class PagoModel
    {
        [Key]
        public int ComercioCodigo { get; set; }
        public string? ComercioNombre { get; set; } 
        public string? ComercioNit { get; set; } 
        public string? ComercioDireccion { get; set; }
        public int TransCodigo { get; set; }
        public int TransMedioPago { get; set; }
        public int TransEstado { get; set; }
        public decimal TransTotal { get; set; }
        public string? TransFecha { get; set; } 
        public string? TransConcepto { get; set; }
        public string? UsuarioIdentificacion { get; set; } 
        public string? UsuarioNombre { get; set; } 
        public string? UsuarioEmail { get; set; } 
    }
}
