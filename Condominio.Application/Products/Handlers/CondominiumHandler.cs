using AutoMapper;
using Condominio.Application.Models;
using Condominio.Application.Products.Commands.Requests;
using Condominio.Application.Products.Commands.Responses;
using Condominio.Application.Products.Queries;
using Condominio.Core.Helpers;
using Condominio.Domain.Entities;
using Condominio.Domain.Interfaces;
using Condominio.Core.Extensions;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Condominio.Application.Products.Handlers
{
    public class CondominiumHandler : 
        IRequestHandler<CreateCondominiumCommand, Result<CreateCondominiumResponse>>,
        IRequestHandler<GetAllCondominiumsQuery, Result<IEnumerable<CondominiumResponse>>>,
        IRequestHandler<GetCondominiumByIdQuery, Result<CondominiumByIdResponse>>
    {

        private readonly ICondominiumRepository _condominiumRepository;
        private readonly IMapper _mapper;

        public CondominiumHandler(ICondominiumRepository condominiumRepository, IMapper mapper)
        {
            this._condominiumRepository = condominiumRepository;
            this._mapper = mapper;
        }

        public async Task<Result<CreateCondominiumResponse>> Handle(CreateCondominiumCommand request, CancellationToken cancellationToken)
        {
            Condominium entity = _mapper.Map<Condominium>(request);
            await _condominiumRepository.CreateCondominium(entity);
            var id = new CreateCondominiumResponse(entity.Id);

            return id.ValidateResultCreate();
        }

        public async Task<Result<IEnumerable<CondominiumResponse>>> Handle(GetAllCondominiumsQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Condominium> result = await _condominiumRepository.GetAllCondominiums();
            var mappedResult = _mapper.Map<IEnumerable<CondominiumResponse>>(result);
            
            return mappedResult.ValidateResultGetAll();
        }

        public async Task<Result<CondominiumByIdResponse>> Handle(GetCondominiumByIdQuery request, CancellationToken cancellationToken)
        {
            Condominium result = await _condominiumRepository.GetCondominiumById(request.Id);
            var mappedResult = _mapper.Map<CondominiumByIdResponse>(result);

            return mappedResult.ValidateResultGetById();
        }
    }
}
