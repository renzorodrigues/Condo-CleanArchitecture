using System;

namespace Condominio.Application.Products.Commands.Responses
{
    public class CreateCondominiumResponse
    {
        public Guid Id { get; set; }

        public CreateCondominiumResponse(Guid id)
        {
            this.Id = id;
        }
    }
}
