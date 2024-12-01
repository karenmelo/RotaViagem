using AutoMapper;
using RotaViagem.Application.DTOs;
using RotaViagem.Domain.Entities;

namespace RotaViagem.Application.Mapping
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Rota, RotaDto>().ReverseMap();
        }
    }
}
