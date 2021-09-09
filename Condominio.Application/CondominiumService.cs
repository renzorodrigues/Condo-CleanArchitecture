using Condominio.Application.DTOs;
using Condominio.Application.Interfaces.Services;
using Condominio.Domain.Entities;
using Condominio.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Condominio.Application
{
    public class CondominiumService : ICondominiumService
    {
        private readonly ICondominiumRepository condominiumRepository;

        public CondominiumService(ICondominiumRepository condominiumRepository)
        {
            this.condominiumRepository = condominiumRepository;
        }

        public Task<IEnumerable<Condominium>> GetCondominiums()
        {
            return this.condominiumRepository.GetCondominiums();
        }
    }
}
