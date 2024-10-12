using AndyJavier_AP1_P1.DAL;
using AndyJavier_AP1_P1.Models;
using Microsoft.EntityFrameworkCore;

public class DeudorServices
{
    private readonly Contexto _contexto;

    public DeudorServices(Contexto contexto)
    {
        _contexto = contexto;
    }

    public async Task<List<Deudor>> Listar()
    {
        return await _contexto.Deudores.ToListAsync();
    }

    public async Task<List<Deudor>> ListarConClientes()
    {
        return await _contexto.Deudores
            .Include(d => d.Cliente) // Asegúrate de incluir la relación
            .ToListAsync();
    }

    public async Task<Deudor?> Buscar(int deudorId)
    {
        return await _contexto.Deudores
            .Include(d => d.Cliente) // Incluir la relación con Cliente
            .FirstOrDefaultAsync(d => d.DeudorId == deudorId);
    }

    public async Task<bool> Insertar(Deudor deudor)
    {
        _contexto.Deudores.Add(deudor);
        return await _contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(Deudor deudor)
    {
        _contexto.Deudores.Update(deudor);
        return await _contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Eliminar(int deudorId)
    {
        var deudor = await Buscar(deudorId);
        if (deudor == null) return false;

        _contexto.Deudores.Remove(deudor);
        return await _contexto.SaveChangesAsync() > 0;
    }
}
