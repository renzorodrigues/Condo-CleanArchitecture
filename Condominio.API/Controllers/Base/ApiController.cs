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

        protected async Task<IActionResult> ExecuteQueryAsync<TRequest, TResult>(TRequest request) where TRequest : class, IQuery<TResult>
        {
            return await ExecuteAsync<TRequest, TResult>(request);
        }

        protected async Task<IActionResult> ExecuteCommandAsync<TRequest, TResult>(TRequest request) where TRequest : class, IRequest<Result<TResult>>
        {
            return await ExecuteAsync<TRequest, TResult>(request);
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
                    Errors = errors.Select(x => new Errors(x.PropertyName, x.ErrorMessage)).ToList()
                };

                return actionResult = BadRequest(validationError);
            }

            var result = await _mediator.Send(request);

            if (result.IsSuccess)
            {
                actionResult = result.StatusCode switch
                {
                    HttpStatusCode.Created => Created(new Uri(Request.GetEncodedUrl() + "/" + result.Data.GetType().GetProperty("Id").GetValue(result.Data)), result),
                    HttpStatusCode.NotFound => NotFound(result),
                    _ => Ok(result),
                };
            }
            else
                actionResult = BadRequest(result);

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