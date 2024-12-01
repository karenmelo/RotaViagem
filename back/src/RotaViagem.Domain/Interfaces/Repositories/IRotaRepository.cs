using RotaViagem.Domain.Entities;

namespace RotaViagem.Domain.Interfaces.Repositories;

public interface IRotaRepository{

    Task<IEnumerable<Rota>> GetByOrginDestiny(string origin, string destiny);
    Task<Rota> CreateAsync(Rota rota);
    Task<Rota> UpdateAsync(Rota rota);
    Task<Rota> RemoveAsync(Rota rota);
}