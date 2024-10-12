using System.ComponentModel.DataAnnotations;

namespace AndyJavier_AP1_P1.Models
{
    public class ClientesDetalle
    {
        [Key]
        public int DetalleId { get; set; }
        public int ClienteId { get; set; }
        public int TipoId { get; set; }
        public string? Telefono { get; set; }

        public Cliente? Cliente { get; set; }
    }

}
