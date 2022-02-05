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
        IRequestHandler<GetAllUnitsQuery, Result<IEnumerable<GetAllUnitsResponse>>>
    {

        private readonly IUnitRepository _unitRepository;
        private readonly IMapper _mapper;

        public UnitHandler(IUnitRepository condominiumRepository, IMapper mapper, INotificationService notificationService)
        {
            this._unitRepository = condominiumRepository;
            this._mapper = mapper;
        }

        public async Task<Result<IEnumerable<GetAllUnitsResponse>>> Handle(GetAllUnitsQuery request, CancellationToken cancellationToken)
        {
            if (request.BlockId == Guid.Empty)
                return _mapper.Map<IEnumerable<GetAllUnitsResponse>>(null).ValidateResultBadRequest("O BlockId deve ser informado.");

            IEnumerable<Domain.Entities.Unit> result = await _unitRepository.GetUnitsByBlockId(request.BlockId);
            var mappedResult = _mapper.Map<IEnumerable<GetAllUnitsResponse>>(result);

            return mappedResult.ValidateResultGetAll();
        }
    }
}
