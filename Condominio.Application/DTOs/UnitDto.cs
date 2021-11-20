using System;

namespace Condominio.Application.DTOs
{
    public class UnitDto
    {
        public  Guid Id{ get; set; }
        public string Code { get; private set; }
        public double Size { get; private set; }
    }
}