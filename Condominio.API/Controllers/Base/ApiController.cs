using Condominio.Core.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using MediatR;
using System.Threading.Tasks;
using Condominio.Core.Handlers.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using FluentValidation;
using System.Linq;
using Microsoft.AspNetCore.Http.Extensions;
using FluentValidation.Results;
using System.Collections.Generic;

namespace Condominio.API.Controllers.Base
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class ApiController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IServiceProvider _serviceProvider;

        public ApiController(IMediator mediator, IServiceProvider serviceProvider)
        {
            this._mediator = mediator;
            this._serviceProvider = serviceProvider;
        }

        // QUERIES
        protected async Task<IActionResult> ExecuteQueryAsync<TRequest, TResult>(TRequest request) where TRequest : class, IQuery<TResult>
        {
            return await ExecuteAsync<TRequest, TResult>(request);
        }

        protected async Task<IActionResult> ExecuteQueryAsync<TRequest, TResult>() where TRequest : class, IQuery<TResult>, new()
        {
            return await ExecuteAsync<TRequest, TResult>(new TRequest());
        }

        // COMMANDS
        protected async Task<IActionResult> ExecuteCommandAsync<TRequest, TResult>(TRequest request) where TRequest : class, ICommand<TResult>
        {
            return await ExecuteAsync<TRequest, TResult>(request);
        }

        protected async Task<IActionResult> ExecuteCommandAsync<TRequest>(TRequest request) where TRequest : class, ICommand
        {
            return await ExecuteAsync<TRequest, Unit>(request);
        }

        private async Task<IActionResult> ExecuteAsync<TRequest, TResult>(TRequest request) where TRequest : class, IRequest<Result<TResult>>
        {
            IActionResult actionResult;

            var errors = this.ValidateRequest(request);

            if (errors.Count > 0)
            {
                var validationError = new Result<List<ValidationFailure>>(null)
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Errors = errors.Select(x => new Error(x.ErrorMessage)).ToList()
                };

                return actionResult = BadRequest(validationError);
            }

            var result = await _mediator.Send(request);

            if (result.IsSuccess)
            {
                var id = result.Data.ToString();
                var url = Request.GetEncodedUrl() + "/" + id;
                actionResult = result.StatusCode switch
                {                    
                    HttpStatusCode.Created => Created(url, result),
                    _ => Ok(result)
                };
            }
            else
            {
                actionResult = result.StatusCode switch
                {
                    HttpStatusCode.NotFound => NotFound(result),
                    HttpStatusCode.Unauthorized => Unauthorized(result),
                    _ => BadRequest(result)
                };
            }

            return actionResult;
        }

        private List<ValidationFailure> ValidateRequest<TRequest>(TRequest request)
        {
            var validator = _serviceProvider.GetServices<IValidator<TRequest>>();

            var errors = validator
                .Select(v => v.Validate(request))
                .SelectMany(result => result.Errors)
                .Where(f => f != null)
                .ToList();

            return errors;
        }
    }
}