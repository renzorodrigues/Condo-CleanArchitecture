using AutoMapper;
using Condominio.Application.Products.Commands.Condominium;
using Condominio.Application.Products.Queries.Condominium;
using Condominio.Application.Models.Condominium;
using Condominio.Core.Helpers;
using Condominio.Domain.Entities;
using Condominio.Domain.Interfaces;
using Condominio.Core.Extensions;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using System;
using Condominio.Application.Interfaces.Services;

namespace Condominio.Application.Products.Handlers
{
    public class CondominiumHandler : 
        IRequestHandler<CreateCondominiumCommand, Result<Guid>>,
        IRequestHandler<GetAllCondominiumsQuery, Result<IEnumerable<GetAllCondominiumsResponse>>>,
        IRequestHandler<GetCondominiumByIdQuery, Result<GetCondominiumByIdResponse>>
    {

        private readonly ICondominiumRepository _condominiumRepository;
        private readonly IMapper _mapper;

        public CondominiumHandler(ICondominiumRepository condominiumRepository, IMapper mapper, INotificationService notificationService)
        {
            this._condominiumRepository = condominiumRepository;
            this._mapper = mapper;
        }

        public async Task<Result<Guid>> Handle(CreateCondominiumCommand request, CancellationToken cancellationToken)
        {
            Condominium entity = _mapper.Map<Condominium>(request);
            await _condominiumRepository.CreateCondominium(entity);

            return entity.Id.ValidateResultCreated();
        }

        public async Task<Result<IEnumerable<GetAllCondominiumsResponse>>> Handle(GetAllCondominiumsQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Condominium> result = await _condominiumRepository.GetAllCondominiums();
            var mappedResult = _mapper.Map<IEnumerable<GetAllCondominiumsResponse>>(result);
           
            return mappedResult.ValidateResultGetAll();
        }

        public async Task<Result<GetCondominiumByIdResponse>> Handle(GetCondominiumByIdQuery request, CancellationToken cancellationToken)
        {
            Condominium result = await _condominiumRepository.GetCondominiumById(request.Id);
            var mappedResult = _mapper.Map<GetCondominiumByIdResponse>(result);

            return mappedResult.ValidateResultGetById();
        }
    }
}
