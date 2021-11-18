using Condominio.Core.Helpers;
using MediatR;

namespace Condominio.Core.Handlers.Interfaces
{
    public interface IQuery<TResponse> : IRequest<Result<TResponse>>
    {
    }
}
