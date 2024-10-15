using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AndyJavier_AP1_P1.Models
{
    public class CobrosDetalle
    {
        [Key]
        public int DetalleId { get; set; }

        public int CobroId { get; set; }

        [ForeignKey("CobroId")]
        public Cobro? Cobro { get; set; }

        [Required(ErrorMessage = "Por favor, verifique el PrestamoId e intente nuevamente.")]
        public int PrestamoId { get; set; }

        [ForeignKey("PrestamoId")]
        public Prestamo? Prestamo { get; set; }

        [Required(ErrorMessage = "El valor cobrado es obligatorio. Por favor, intente nuevamente.")]
        public decimal? ValorCobrado { get; set; }
    }
}