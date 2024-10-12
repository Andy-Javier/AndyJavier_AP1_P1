using AndyJavier_AP1_P1.DAL;
using AndyJavier_AP1_P1.Models;
using Microsoft.EntityFrameworkCore;

public class CobroDetalleServices
{
    private readonly Contexto _contexto;

    public CobroDetalleServices(Contexto contexto)
    {
        _contexto = contexto;
    }

    public async Task<List<CobroDetalle>> Listar()
    {
        return await _contexto.CobroDetalles.ToListAsync();
    }

    public async Task<CobroDetalle?> Buscar(int detalleId)
    {
        return await _contexto.CobroDetalles.FindAsync(detalleId);
    }

    public async Task<bool> Insertar(CobroDetalle detalle)
    {
        _contexto.CobroDetalles.Add(detalle);
        return await _contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(CobroDetalle detalle)
    {
        _contexto.CobroDetalles.Update(detalle);
        return await _contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Eliminar(int detalleId)
    {
        var detalle = await Buscar(detalleId);
        if (detalle == null) return false;

        _contexto.CobroDetalles.Remove(detalle);
        return await _contexto.SaveChangesAsync() > 0;
    }
}
