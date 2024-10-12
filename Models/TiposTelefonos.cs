using System.ComponentModel.DataAnnotations;

namespace AndyJavier_AP1_P1.Models
{
    public class TiposTelefonos
    {
        [Key]
        public int TipoId { get; set; }
        public string? Descripcion { get; set; }
    }

}
