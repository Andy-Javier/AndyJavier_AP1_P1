using AndyJavier_AP1_P1.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace AndyJavier_AP1_P1.DAL
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options)
            : base(options) { }

        public DbSet<Prestamo> Prestamos { get; set; }
        public DbSet<Deudor> Deudores { get; set; }
        public DbSet<Cobro> Cobros { get; set; }
        public DbSet<CobrosDetalle> CobroDetalles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Deudor>().HasData(new List<Deudor>()
            {
                new Deudor() { DeudorId = 1, Nombres = "Andy" },
                new Deudor() { DeudorId = 2, Nombres = "Marian" },
                new Deudor() { DeudorId = 3, Nombres = "Anderson" }
            });
        }
    }
}