using System.Collections.Generic;
using System.Threading.Tasks;
using Condominio.Application.DTOs;
using Condominio.Domain.Entities;

namespace Condominio.Application.Interfaces.Services
{
    public interface ICondominiumService
    {
        Task<IEnumerable<Condominium>> GetCondominiums();
    }
}