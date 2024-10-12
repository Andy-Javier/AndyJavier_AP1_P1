using System.ComponentModel.DataAnnotations;

namespace AndyJavier_AP1_P1.Models;

public class Deudor
{
    [Key]
    public int DeudorId { get; set; }

    [Required]
    public string? Nombres { get; set; }
}
