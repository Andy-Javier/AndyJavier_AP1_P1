using System.ComponentModel.DataAnnotations;

namespace AndyJavier_AP1_P1.Models
{
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }
        public string? Nombres { get; set; }
        public string? Rnc { get; set; }
        public string? Direccion { get; set; }
        public decimal LimiteCredito { get; set; }
        public List<ClientesDetalle> Telefonos { get; set; } = new List<ClientesDetalle>();
    }

}
