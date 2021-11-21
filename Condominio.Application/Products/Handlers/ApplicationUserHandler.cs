using AutoMapper;
using Condominio.Core.Helpers;
using Condominio.Domain.Entities;
using Condominio.Domain.Interfaces;
using Condominio.Core.Extensions;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using System;
using Condominio.Application.Products.Commands.ApplicationUser;

namespace Condominio.Application.Products.Handlers
{
    public class ApplicationUserHandler : 
        IRequestHandler<CreateApplicationUserCommand, Result<Guid>>
    {

        private readonly IApplicationUserRepository _applicationUserRepository;
        private readonly IMapper _mapper;

        public ApplicationUserHandler(IApplicationUserRepository applicationUserRepository, IMapper mapper)
        {
            this._applicationUserRepository = applicationUserRepository;
            this._mapper = mapper;
        }

        public async Task<Result<Guid>> Handle(CreateApplicationUserCommand request, CancellationToken cancellationToken)
        {
            ApplicationUser entity = _mapper.Map<ApplicationUser>(request);
            await _applicationUserRepository.CreateApplicationUser(entity);

            return entity.Id.ValidateResultCreate();
        }
    }
}
