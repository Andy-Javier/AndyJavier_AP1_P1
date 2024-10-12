using AndyJavier_AP1_P1.DAL;
using AndyJavier_AP1_P1.Models;
using Microsoft.EntityFrameworkCore;

public class ClienteServices
{
    private readonly Contexto _contexto;

    public ClienteServices(Contexto contexto)
    {
        _contexto = contexto;
    }

    public async Task<List<Cliente>> Listar()
    {
        return await _contexto.Clientes.ToListAsync();
    }

    public async Task<Cliente?> Buscar(int clienteId)
    {
        return await _contexto.Clientes.FindAsync(clienteId);
    }

    public async Task<bool> Insertar(Cliente cliente)
    {
        _contexto.Clientes.Add(cliente);
        return await _contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(Cliente cliente)
    {
        _contexto.Clientes.Update(cliente);
        return await _contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Eliminar(int clienteId)
    {
        var cliente = await Buscar(clienteId);
        if (cliente == null) return false;

        _contexto.Clientes.Remove(cliente);
        return await _contexto.SaveChangesAsync() > 0;
    }
}
