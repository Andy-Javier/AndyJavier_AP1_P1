using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AndyJavier_AP1_P1.Models;

public class Prestamo
{
    [Key]
    public int PrestamoId { get; set; }

    [Required(ErrorMessage = "El campo 'Concepto' es obligatorio.")]
    public string? Concepto { get; set; }

    [Required(ErrorMessage = "El campo 'Monto' es obligatorio.")]
    public decimal Monto { get; set; }

    [Required(ErrorMessage = "El campo 'Balance' es obligatorio.")]
    public decimal Balance { get; set; }

    [Required(ErrorMessage = "El campo 'DeudorId' es obligatorio.")]
    public int DeudorId { get; set; }

    [ForeignKey("DeudorId")]
    public Deudor? Deudor { get; set; }

    public List<CobrosDetalle> CobroDetalles { get; set; } = new List<CobrosDetalle>();
}