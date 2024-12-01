using AutoMapper;
using RotaViagem.Application.DTOs;
using RotaViagem.Application.Services.Interfaces;
using RotaViagem.Domain.Entities;
using RotaViagem.Domain.Interfaces.Repositories;

namespace RotaViagem.Application.Services
{
    public class RotaService : IRotaService
    {
        private readonly IRotaRepository _rotaRepository;
        private readonly IMapper _mapper;
        public RotaService(IRotaRepository rotaRepository, IMapper mapper)
        {
            _rotaRepository = rotaRepository;
            _mapper = mapper;
        }

        public async Task CreateAsync(RotaDto rota)
        {
            await _rotaRepository.CreateAsync(_mapper.Map<Rota>(rota));
        }

        public async Task<RotaDto> GetById(int id)
        {
            var result = await _rotaRepository.GetById(id);
            return _mapper.Map<RotaDto>(result);
        }

        public async Task<IEnumerable<RotaDto>> GetByOrginDestiny(string origem, string destino)
        {
            var result = await _rotaRepository.GetByOrginDestiny(origem, destino);
            return _mapper.Map<IEnumerable<RotaDto>>(result);
        }

        public async Task RemoveAsync(int id)
        {
            var rota = await _rotaRepository.GetById(id);
            await _rotaRepository.RemoveAsync(_mapper.Map<Rota>(rota));
        }

        public async Task<RotaDto> UpdateAsync(RotaDto rota)
        {
            var result = await _rotaRepository.UpdateAsync(_mapper.Map<Rota>(rota));
            return _mapper.Map<RotaDto>(result);
        }
    }
}
