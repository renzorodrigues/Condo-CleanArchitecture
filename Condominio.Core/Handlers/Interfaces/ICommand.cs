using Condominio.Core.Helpers;
using MediatR;

namespace Condominio.Core.Handlers.Interfaces
{
    public interface ICommand<TResult> : IRequest<Result<TResult>>
    {
    }

    public interface ICommand : IRequest<Result<Unit>>
    {
    }
}
