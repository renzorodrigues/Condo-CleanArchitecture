using AutoMapper;
using Condominio.Application.DTOs;
using Condominio.Application.Models.Condominium;
using Condominio.Application.Models.Unit;
using Condominio.Application.Products.Commands.Account;
using Condominio.Application.Products.Commands.Condominium;
using Condominio.Domain.Entities;
using Condominio.Domain.Entities.Account;
using Condominio.Domain.Models;

namespace Condominio.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCondominiumCommand, Condominium>().ReverseMap()
                .ForMember(x => x.Address, d => d.MapFrom(o => o.Address));

            CreateMap<GetCondominiumByIdResponse, Condominium>().ReverseMap()
                .ForMember(x => x.Address, d => d.MapFrom(o => o.Address));

            CreateMap<BlockDto, Block>().ReverseMap();

            CreateMap<Address, AddressDto>().ReverseMap();
            
            CreateMap<UnitDto, Unit>().ReverseMap();

            CreateMap<Condominium, GetAllCondominiumsResponse>().ReverseMap();

            CreateMap<UnitsPagedResponse, GetUnitsPagedResponse>().ReverseMap();

            CreateMap<AccountRegisterCommand, AppUser>().ReverseMap();
            
            CreateMap<AccountLoginCommand, AppUser>().ReverseMap();
        }
    }
}
