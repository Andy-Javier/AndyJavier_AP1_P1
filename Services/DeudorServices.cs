using Microsoft.EntityFrameworkCore;
using AndyJavier_AP1_P1.DAL;
using AndyJavier_AP1_P1.Models;
using System.Linq.Expressions;

namespace AndyJavier_AP1_P1.Services
{
    public class DeudorServices
    {
        private readonly Contexto _contexto;

        public DeudorServices(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<List<Deudor>> Listar()
        {
            return await _contexto.Deudores.AsNoTracking().ToListAsync();
        }
    }
}