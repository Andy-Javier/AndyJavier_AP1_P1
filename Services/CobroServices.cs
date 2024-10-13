using AndyJavier_AP1_P1.DAL;
using AndyJavier_AP1_P1.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AndyJavier_AP1_P1.Services;

public class CobroServices
{
    private readonly Contexto _contexto;

    public CobroServices(Contexto contexto)
    {
        _contexto = contexto;
    }

    // Método Existe
    public async Task<bool> Existe(int cobroId)
    {
        return await _contexto.Cobros.AnyAsync(c => c.CobroId == cobroId);
    }

    // Método Insertar 
    private async Task<bool> Insertar(Cobro cobro)
    {
        _contexto.Cobros.Add(cobro);
        return await _contexto.SaveChangesAsync() > 0;
    }

    // Método Modificar
    public async Task<bool> Modificar(Cobro cobro)
    {
        var cobroExistente = await _contexto.Cobros
            .Include(c => c.CobroDetalles)
            .FirstOrDefaultAsync(c => c.CobroId == cobro.CobroId);

        if (cobroExistente != null)
        {
            foreach (var detalleExistente in cobroExistente.CobroDetalles.ToList())
            {
                if (!cobro.CobroDetalles.Any(d => d.DetalleId == detalleExistente.DetalleId))
                {
                    _contexto.CobroDetalles.Remove(detalleExistente);
                }
            }

            cobroExistente.CobroDetalles = cobro.CobroDetalles;

            _contexto.Entry(cobroExistente).CurrentValues.SetValues(cobro);
            return await _contexto.SaveChangesAsync() > 0;
        }
        return false;
    }

    // Método Guardar 
    public async Task<bool> Guardar(Cobro cobro)
    {
        if (!await Existe(cobro.CobroId))
            return await Insertar(cobro);
        else
            return await Modificar(cobro);
    }

    // Método Eliminar
    public async Task<bool> Eliminar(int id)
    {
        var eliminado = await _contexto.Cobros
            .Where(c => c.CobroId == id)
            .ExecuteDeleteAsync();
        return eliminado > 0;
    }

    // Método Buscar 
    public async Task<Cobro?> Buscar(int id)
    {
        return await _contexto.Cobros
            .AsNoTracking()
            .Include(c => c.Deudor)
            .Include(c => c.CobroDetalles)
            .FirstOrDefaultAsync(c => c.CobroId == id);
    }

    // Método Listar
    public async Task<List<Cobro>> Listar(Expression<Func<Cobro, bool>> criterio)
    {
        return await _contexto.Cobros
            .AsNoTracking()
            .Include(c => c.Deudor)
            .Include(c => c.CobroDetalles)
            .Where(criterio)
            .ToListAsync();
    }

    // Este método me ayuda a coleccionar los deudores que tengo registrados en mi tabla de préstamos
    public async Task<List<Deudor>> ListarDeudores()
    {
        return await _contexto.Deudores
            .AsNoTracking()
            .ToListAsync();
    }

    // Método ObtenerDeudoresConPrestamos ya guardados con su respectivo monto
    public async Task<List<Deudor>> ObtenerDeudoresConPrestamos()
    {
        return await _contexto.Prestamos
            .Include(p => p.Deudor)
            .Select(p => p.Deudor)
            .Distinct()
            .ToListAsync();
    }

    public async Task<List<Prestamo>> ObtenerPrestamosPorDeudorId(int deudorId)
    {
        return await _contexto.Prestamos
            .Where(p => p.DeudorId == deudorId)
            .OrderByDescending(p => p.PrestamoId)
            .ToListAsync();
    }
}
