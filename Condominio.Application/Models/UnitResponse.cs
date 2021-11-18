using System;

namespace Condominio.Application.Models
{
    public class UnitResponse
    {
        public  Guid Id{ get; set; }
        public string Code { get; private set; }
        public double Size { get; private set; }
    }
}