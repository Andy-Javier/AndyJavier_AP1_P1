using Microsoft.EntityFrameworkCore;
using AndyJavier_AP1_P1.Models;
using Microsoft.Win32;

namespace AndyJavier_AP1_P1.DAL;

public class Contexto : DbContext
{

    public Contexto(DbContextOptions<Contexto> options)
        : base(options) { }
    public DbSet<Registro> Registros { get; set; }
}