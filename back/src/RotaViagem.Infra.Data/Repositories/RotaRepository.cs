using Microsoft.EntityFrameworkCore;
using RotaViagem.Domain.Entities;
using RotaViagem.Domain.Interfaces.Repositories;
using RotaViagem.Infra.Data.Context;

namespace RotaViagem.Infra.Data.Repositories;

public class RotaRepository : IRotaRepository {

private readonly AppDbContext _context;
 
 public RotaRepository(AppDbContext context) => _context = context;
 public async Task<Rota> CreateAsync(Rota rota)
    {
        _context.Rotas.Add(rota);
        await _context.SaveChangesAsync();
        return rota;
    }

    public async Task<IEnumerable<Rota>> GetByOrginDestiny(string origem, string destino)
    {
        return await _context.Rotas
                             .Where(x => x.Origem == origem && x.Destino == destino)
                             .ToListAsync();
    }

    public async Task<Rota> RemoveAsync(Rota rota)
    {
        _context.Rotas.Remove(rota);
        await _context.SaveChangesAsync();
        return rota;
    }

    public async Task<Rota> UpdateAsync(Rota rota)
    {
        _context.Rotas.Update(rota);
        await _context.SaveChangesAsync();
        return rota;
    }
}