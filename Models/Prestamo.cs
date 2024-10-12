using System.ComponentModel.DataAnnotations;

namespace AndyJavier_AP1_P1.Models;

public class Prestamo
{
    [Key]
    public int PrestamoId { get; set; }

    [Required]
    public int DeudorId { get; set; }

    public Deudor? Deudor { get; set; }

    [Required]
    public string? Concepto { get; set; }

    [Required]
    public int Monto { get; set; }

    public decimal Balance { get; set; }

}
