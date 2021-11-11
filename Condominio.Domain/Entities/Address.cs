namespace Condominio.Domain.Entities
{
    public sealed class Address
    {
        public string PublicPlace { get; private set; }
        public string Number { get; private set; }
        public string Complement { get; private set; }
        public string ZipCode { get; private set; }
        public string District { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }

        public Address(string publicPlace, string number, string complement, string zipCode, string district, string city, string state)
        {
            this.PublicPlace = publicPlace;
            this.Number = number;
            this.Complement = complement;
            this.ZipCode = zipCode;
            this.District = district;
            this.City = city;
            this.State = state;
        }
    }
}
