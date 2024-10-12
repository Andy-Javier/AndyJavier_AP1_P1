using AndyJavier_AP1_P1.DAL;
using AndyJavier_AP1_P1.Models;
using Microsoft.EntityFrameworkCore;

public class TiposTelefonosServices
{
    private readonly Contexto _contexto;

    public TiposTelefonosServices(Contexto contexto)
    {
        _contexto = contexto;
    }

    public async Task<List<TiposTelefonos>> Listar()
    {
        return await _contexto.TiposTelefonos.ToListAsync();
    }

    public async Task<TiposTelefonos?> Buscar(int tipoId)
    {
        return await _contexto.TiposTelefonos.FindAsync(tipoId);
    }

    public async Task<bool> Insertar(TiposTelefonos tipo)
    {
        _contexto.TiposTelefonos.Add(tipo);
        return await _contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(TiposTelefonos tipo)
    {
        _contexto.TiposTelefonos.Update(tipo);
        return await _contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Eliminar(int tipoId)
    {
        var tipo = await Buscar(tipoId);
        if (tipo == null) return false;

        _contexto.TiposTelefonos.Remove(tipo);
        return await _contexto.SaveChangesAsync() > 0;
    }
}
