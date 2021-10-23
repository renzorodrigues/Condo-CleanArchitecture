using Condominio.Domain.ValueObjects.Base;
using System.Collections.Generic;

namespace Condominio.Domain.ValueObjects
{
    public sealed class Address : ValueObjectBase
    {
        public string PublicPlace { get; private set; }
        public string Number { get; private set; }
        public string Complement { get; private set; }
        public string ZipCode { get; private set; }
        public string District { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return PublicPlace;
            yield return Number;
            yield return Complement;
            yield return ZipCode;
            yield return District;
            yield return City;
            yield return State;
        }
    }
}
