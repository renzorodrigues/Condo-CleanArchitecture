using System;
using System.Threading.Tasks;
using Condominio.Domain.Entities;

namespace Condominio.Domain.Interfaces
{
    public interface ICredentialRepository
    {
        Task CreateCredential(Credential entity);
        Task<Credential> Authenticate(string email);
    }
}