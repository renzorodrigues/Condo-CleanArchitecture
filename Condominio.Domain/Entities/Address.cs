using System;
using Condominio.Domain.Entities.Base;

namespace Condominio.Domain.Entities
{
    public sealed class Address : EntityBase
    {
        public string PublicPlace { get; private set; }
        public string Number { get; private set; }
        public string Complement { get; private set; }
        public string ZipCode { get; private set; }
        public string District { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public Guid CondominiumId { get; set; }
        public Condominium Condominium { get; set; }
    }
}
