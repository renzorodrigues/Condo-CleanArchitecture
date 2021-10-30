using AutoMapper;
using Condominio.Application.DTOs;
using Condominio.Domain.Entities;

namespace Condominio.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Condominium, CondominiumDto>()
                .ForMember(d => d.PublicPlace, o => o.MapFrom(s => s.Address.PublicPlace))
                .ForMember(d => d.Number, o => o.MapFrom(s => s.Address.Number))
                .ForMember(d => d.Complement, o => o.MapFrom(s => s.Address.Complement))
                .ForMember(d => d.ZipCode, o => o.MapFrom(s => s.Address.ZipCode))
                .ForMember(d => d.District, o => o.MapFrom(s => s.Address.District))
                .ForMember(d => d.City, o => o.MapFrom(s => s.Address.City))
                .ForMember(d => d.State, o => o.MapFrom(s => s.Address.State));

            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
