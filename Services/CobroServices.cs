using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using AndyJavier_AP1_P1.DAL;
using AndyJavier_AP1_P1.Models;

namespace AndyJavier_AP1_P1.Services
{
    public class CobroServices
    {
        private readonly Contexto _contexto;

        public CobroServices(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<bool> Existe(int cobroId)
        {
            return await _contexto.Cobros.AnyAsync(c => c.CobroId == cobroId);
        }

        private async Task<bool> Insertar(Cobro cobro)
        {
            _contexto.Cobros.Add(cobro);
            return await _contexto.SaveChangesAsync() > 0;
        }

        private async Task<bool> Modificar(Cobro cobro)
        {
            _contexto.Cobros.Update(cobro);
            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Guardar(Cobro cobro)
        {
            if (!await Existe(cobro.CobroId))
                return await Insertar(cobro);
            else
                return await Modificar(cobro);
        }

        public async Task<bool> Eliminar(int id)
        {
            var eliminarCobro = await _contexto.Cobros
                .Where(c => c.CobroId == id)
                .ExecuteDeleteAsync();

            return eliminarCobro > 0;
        }

        public async Task<Cobro?> Buscar(int id)
        {
            return await _contexto.Cobros
                .Include(c => c.Deudor)
                .Include(c => c.CobroDetalles)
                    .ThenInclude(cd => cd.Prestamo)
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.CobroId == id);
        }

        public async Task<List<Cobro>> Listar(Expression<Func<Cobro, bool>> criterio)
        {
            return await _contexto.Cobros
                .Include(c => c.CobroDetalles)
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }

        public async Task<List<Deudor>> ObtenerDeudores()
        {
            return await _contexto.Deudores.ToListAsync();
        }

        public async Task<List<Prestamo>> ObtenerPrestamos()
        {
            return await _contexto.Prestamos.ToListAsync();
        }
    }
}