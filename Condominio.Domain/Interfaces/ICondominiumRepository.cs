using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Condominio.Domain.Entities;

namespace Condominio.Domain.Interfaces
{
    public interface ICondominiumRepository
    {
        Task<IEnumerable<Condominium>> GetAllCondominiums();
        Task CreateCondominium(Condominium entity);
        Task<Condominium> GetCondominiumById(Guid id);
    }
}