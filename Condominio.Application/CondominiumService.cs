using AutoMapper;
using Condominio.Application.DTOs;
using Condominio.Application.Interfaces.Services;
using Condominio.Domain.Entities;
using Condominio.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Condominio.Application
{
    public class CondominiumService : ICondominiumService
    {
        private readonly ICondominiumRepository _condominiumRepository;
        private readonly IMapper _mapper;

        public CondominiumService(ICondominiumRepository condominiumRepository, IMapper mapper)
        {
            this._condominiumRepository = condominiumRepository;
            this._mapper = mapper;
        }

        public Task CreateCondominium(Condominium entity)
        {
            return this._condominiumRepository.CreateCondominium(entity);
        }

        public async Task<IEnumerable<CondominiumDto>> GetCondominiums()
        {
            var result = await this._condominiumRepository.GetCondominiums();
            var list = this._mapper.Map<IEnumerable<CondominiumDto>>(result);
            return list;
        }
    }
}
