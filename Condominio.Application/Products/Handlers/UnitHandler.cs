using AutoMapper;
using Condominio.Core.Helpers;
using Condominio.Domain.Interfaces;
using Condominio.Core.Extensions;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Condominio.Application.Interfaces.Services;
using Condominio.Application.Models.Unit;
using Condominio.Application.Products.Queries.Unit;
using System;

namespace Condominio.Application.Products.Handlers
{
    public class UnitHandler : 
        IRequestHandler<GetUnitsPagedQuery, Result<GetUnitsPagedResponse>>
    {

        private readonly IUnitRepository _unitRepository;
        private readonly IMapper _mapper;

        public UnitHandler(IUnitRepository unitRepository, IMapper mapper, INotificationService notificationService)
        {
            this._unitRepository = unitRepository;
            this._mapper = mapper;
        }

        public async Task<Result<GetUnitsPagedResponse>> Handle(GetUnitsPagedQuery request, CancellationToken cancellationToken)
        {
            if (request.BlockId == Guid.Empty)
                return _mapper.Map<GetUnitsPagedResponse>(null).ValidateResultBadRequest("O BlockId deve ser informado.");

            var result = await _unitRepository.GetUnitsPagedByBlockId(request.BlockId, request.PageNumber, request.PageSize);
            var mappedResult = _mapper.Map<GetUnitsPagedResponse>(result);

            return mappedResult.ValidatePagedResult();
        }
    }
}
