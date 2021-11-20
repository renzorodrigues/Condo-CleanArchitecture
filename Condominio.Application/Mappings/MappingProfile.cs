using AutoMapper;
using Condominio.Application.DTOs;
using Condominio.Application.Models.Condominium;
using Condominio.Application.Products.Commands.Account;
using Condominio.Application.Products.Commands.Condominium;
using Condominio.Domain.Entities;

namespace Condominio.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // DOMAIN TO DTO
            CreateMap<Address, AddressDto>().ReverseMap();

            // REQUEST TO DOMAIN
            CreateMap<CreateCondominiumCommand, Condominium>().ReverseMap()
                .ForMember(x => x.Address, d => d.MapFrom(o => o.Address));

            CreateMap<GetCondominiumByIdResponse, Condominium>().ReverseMap()
                .ForMember(x => x.Address, d => d.MapFrom(o => o.Address));
            
            CreateMap<BlockDto, Block>().ReverseMap()
                .ForMember(x => x.Units, d => d.MapFrom(o => o.Units));

            CreateMap<UnitDto, Unit>().ReverseMap();

            CreateMap<GetAllCondominiumsResponse, Condominium>().ReverseMap();
            
            CreateMap<CreateAccountCommand, Credential>().ReverseMap();
        }
    }
}
