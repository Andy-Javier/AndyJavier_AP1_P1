using AndyJavier_AP1_P1.DAL;
using AndyJavier_AP1_P1.Models;
using Microsoft.EntityFrameworkCore;

public class ClientesDetalleServices
{
    private readonly Contexto _contexto;

    public ClientesDetalleServices(Contexto contexto)
    {
        _contexto = contexto;
    }

    public async Task<List<ClientesDetalle>> Listar()
    {
        return await _contexto.ClientesDetalles.ToListAsync();
    }

    public async Task<ClientesDetalle?> Buscar(int detalleId)
    {
        return await _contexto.ClientesDetalles.FindAsync(detalleId);
    }

    public async Task<bool> Insertar(ClientesDetalle detalle)
    {
        _contexto.ClientesDetalles.Add(detalle);
        return await _contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(ClientesDetalle detalle)
    {
        _contexto.ClientesDetalles.Update(detalle);
        return await _contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Eliminar(int detalleId)
    {
        var detalle = await Buscar(detalleId);
        if (detalle == null) return false;

        _contexto.ClientesDetalles.Remove(detalle);
        return await _contexto.SaveChangesAsync() > 0;
    }
}
