using System;
using System.Collections.Generic;

namespace Condominio.Application.Models
{
    public class CondominiumByIdResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public AddressResponse Address{ get; set; }
        public ICollection<BlockResponse> Blocks { get; set; }
    }
}
