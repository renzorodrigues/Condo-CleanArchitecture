using AutoMapper;
using Condominio.Application.Models;
using Condominio.Application.Products.Commands.Requests;
using Condominio.Domain.Entities;

namespace Condominio.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // DOMAIN TO DTO
            CreateMap<Address, AddressResponse>().ReverseMap();

            // REQUEST TO DOMAIN
            CreateMap<CreateCondominiumCommand, Condominium>().ReverseMap()
                .ForMember(x => x.Address, d => d.MapFrom(o => o.Address));

            CreateMap<CondominiumByIdResponse, Condominium>().ReverseMap()
                .ForMember(x => x.Address, d => d.MapFrom(o => o.Address));
            
            CreateMap<BlockResponse, Block>().ReverseMap()
                .ForMember(x => x.Units, d => d.MapFrom(o => o.Units));

            CreateMap<UnitResponse, Unit>().ReverseMap();

            CreateMap<CondominiumResponse, Condominium>().ReverseMap()
                .ForMember(x => x.PublicPlace, d => d.MapFrom(o => o.Address.PublicPlace))
                .ForMember(x => x.Number, d => d.MapFrom(o => o.Address.Number))
                .ForMember(x => x.Complement, d => d.MapFrom(o => o.Address.Complement))
                .ForMember(x => x.ZipCode, d => d.MapFrom(o => o.Address.ZipCode))
                .ForMember(x => x.District, d => d.MapFrom(o => o.Address.District))
                .ForMember(x => x.City, d => d.MapFrom(o => o.Address.City))
                .ForMember(x => x.State, d => d.MapFrom(o => o.Address.State));
        }
    }
}
