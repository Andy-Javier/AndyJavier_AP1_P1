using AndyJavier_AP1_P1.DAL;
using AndyJavier_AP1_P1.Models;
using Microsoft.EntityFrameworkCore;

public class CobroServices
{
    private readonly Contexto _contexto;

    public CobroServices(Contexto contexto)
    {
        _contexto = contexto;
    }

    public async Task<List<Cobro>> Listar()
    {
        return await _contexto.Cobros.ToListAsync();
    }

    public async Task<Cobro?> Buscar(int cobroId)
    {
        return await _contexto.Cobros.FindAsync(cobroId);
    }

    public async Task<bool> Insertar(Cobro cobro)
    {
        _contexto.Cobros.Add(cobro);
        return await _contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(Cobro cobro)
    {
        _contexto.Cobros.Update(cobro);
        return await _contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Eliminar(int cobroId)
    {
        var cobro = await Buscar(cobroId);
        if (cobro == null) return false;

        _contexto.Cobros.Remove(cobro);
        return await _contexto.SaveChangesAsync() > 0;
    }
}
