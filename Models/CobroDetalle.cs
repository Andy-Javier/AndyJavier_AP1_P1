using System.ComponentModel.DataAnnotations;

namespace AndyJavier_AP1_P1.Models
{
    public class CobroDetalle
    {
        [Key]
        public int DetalleId { get; set; }
        public int CobroId { get; set; }
        public Cobro? Cobro { get; set; }
        public int PrestamoId { get; set; }
        public Prestamo? Prestamo { get; set; }
        public decimal ValorCobrado { get; set; }
    }

}
