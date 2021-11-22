using Condominio.Core.Helpers;
using MediatR;

namespace Condominio.Core.Handlers.Interfaces
{
    public interface IQuery<TResult> : IRequest<Result<TResult>>
    {
    }
}
