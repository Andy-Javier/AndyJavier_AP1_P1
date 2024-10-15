using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AndyJavier_AP1_P1.Models;

public class Cobro
{
    [Key]
    public int CobroId { get; set; }

    [Required(ErrorMessage = "Por favor, proporcione una fecha válida.")]
    public DateTime? Fecha { get; set; }

    public int DeudorId { get; set; }

    [ForeignKey("DeudorId")]
    public Deudor? Deudor { get; set; }

    [Required(ErrorMessage = "Es necesario especificar el deudor.")]
    public decimal Monto { get; set; }

    public ICollection<CobrosDetalle> CobroDetalles { get; set; } = new List<CobrosDetalle>();
}