using System.ComponentModel.DataAnnotations;

namespace AndyJavier_AP1_P1.Models
{
    public class Prestamo
    {
        [Key]
        public int PrestamoId { get; set; }
        [Required]
        public string? Deudor { get; set; }
        [Required]
        public string? Concepto { get; set; }
        [Required]
        public int Monto { get; set; }
        
    }
}
