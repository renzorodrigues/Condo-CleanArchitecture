using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Condominio.Application.Products.Commands.Requests;
using Condominio.Domain.Entities;

namespace Condominio.Application.Interfaces.Services
{
    public interface ICondominiumService
    {
        Task<IEnumerable<Condominium>> GetAllCondominiums();
        Task<Guid> CreateCondominium(CreateCondominiumRequest request);
    }
}