

using System.ComponentModel.DataAnnotations;

namespace Pagos.Models
{
    public class Transaccion
    {
        [Key]
        public int TransCodigo { get; set; }
        public int TransMedioPago { get; set; }
        public int TransEstado { get; set; }
        public decimal TransTotal { get; set; }
        public string? TransFecha { get; set; }
        public string? TransConcepto { get; set; }
    }
}
