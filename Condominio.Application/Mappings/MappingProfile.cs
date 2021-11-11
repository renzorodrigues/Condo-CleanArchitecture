using AutoMapper;
using Condominio.Application.DTOs;
using Condominio.Application.Products.Commands.Requests;
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
            CreateMap<CreateCondominiumRequest, Condominium>().ReverseMap()
                .ForMember(x => x.Address, d => d.MapFrom(o => o.Address));
        }
    }
}
