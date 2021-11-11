using AutoMapper;
using Condominio.Application.Products.Commands.Requests;
using Condominio.Application.Products.Commands.Responses;
using Condominio.Application.Products.Queries;
using Condominio.Domain.Entities;
using Condominio.Domain.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Condominio.Application.Products.Handlers
{
    public class CondominiumHandler : 
        IRequestHandler<CreateCondominiumRequest, CreateCondominiumResponse>,
        IRequestHandler<GetAllCondominiumsQuery, IEnumerable<Condominium>>
    {

        private readonly ICondominiumRepository _condominiumRepository;
        private readonly IMapper _mapper;

        public CondominiumHandler(ICondominiumRepository condominiumRepository, IMapper mapper)
        {
            this._condominiumRepository = condominiumRepository;
            this._mapper = mapper;
        }

        public async Task<CreateCondominiumResponse> Handle(CreateCondominiumRequest request, CancellationToken cancellationToken)
        {
            Condominium entity = _mapper.Map<Condominium>(request);
            await _condominiumRepository.CreateCondominium(entity);
            return new CreateCondominiumResponse() { Id = entity.Id };
        }

        public async Task<IEnumerable<Condominium>> Handle(GetAllCondominiumsQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Condominium> result = await _condominiumRepository.GetAllCondominiums();
            return result;
        }
    }
}
