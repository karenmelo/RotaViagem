using RotaViagem.Application.DTOs;

namespace RotaViagem.Application.Services.Interfaces
{
    public interface IRotaService
    {
        Task<RotaDto> GetById(int id);
        Task<IEnumerable<RotaDto>> GetByOrginDestiny(string origem, string destino);
        Task CreateAsync(RotaDto rota);
        Task<RotaDto> UpdateAsync(RotaDto rota);
        Task RemoveAsync(int id);
    }
}
