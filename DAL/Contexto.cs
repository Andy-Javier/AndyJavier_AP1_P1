using Microsoft.EntityFrameworkCore;
using AndyJavier_AP1_P1.Models;

namespace AndyJavier_AP1_P1.DAL
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }

        public DbSet<Prestamo> Prestamos { get; set; }
        public DbSet<Deudor> Deudores { get; set; }
        public DbSet<Cobro> Cobros { get; set; }
        public DbSet<CobroDetalle> CobroDetalles { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<ClientesDetalle> ClientesDetalles { get; set; }
        public DbSet<TiposTelefonos> TiposTelefonos { get; set; }

    }
}
