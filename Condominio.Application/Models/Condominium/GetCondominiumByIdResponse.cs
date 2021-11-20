using Condominio.Application.DTOs;
using System;
using System.Collections.Generic;

namespace Condominio.Application.Models.Condominium
{
    public class GetCondominiumByIdResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public AddressDto Address{ get; set; }
        public ICollection<BlockDto> Blocks { get; set; }
    }
}
