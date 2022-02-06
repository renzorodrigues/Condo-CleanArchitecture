using Microsoft.EntityFrameworkCore;

namespace Condominio.Domain.Entities
{
    public sealed class Telphone
    {
        public string AreaCode { get; private set; }
        public string Number { get; private set; }

        public Telphone(string areaCode, string number)
        {
            this.AreaCode = areaCode;
            this.Number = number;
        }
    }
}