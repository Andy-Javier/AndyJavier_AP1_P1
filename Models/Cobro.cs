using System.ComponentModel.DataAnnotations;

namespace AndyJavier_AP1_P1.Models
{
    public class Cobro
    {
        [Key]
        public int CobroId { get; set; }
        public DateTime Fecha { get; set; }
        public int DeudorId { get; set; }
        public Deudor? Deudor { get; set; }
        public decimal Monto { get; set; }
    }

}
