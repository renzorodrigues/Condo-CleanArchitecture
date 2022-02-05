using Condominio.Core.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Condominio.Core.Extensions
{
    public static class ValidateResultExtension
    {
        public static Result<T> ValidateResultGetById<T>(this T result)
        {
            if (result is null)
                return new Result<T>(result)
                {
                    StatusCode = HttpStatusCode.NotFound,
                    IsSuccess = false,
                    Errors = new List<Error>() { new Error("Objeto não encontrado.") }
                };

            return new Result<T>(result);
        }

        public static Result<T> ValidateResultCreated<T>(this T result)
        {
            return new Result<T>(result)
            {
                StatusCode = HttpStatusCode.Created
            };
        }

        public static Result<IEnumerable<T>> ValidateResultGetAll<T>(this IEnumerable<T> result)
        {
            if (result.Any())
                return new Result<IEnumerable<T>>(result);

            return new Result<IEnumerable<T>>(result) { Message = "A lista está vazia." };
        }

        public static Result<T> AuthenticationOk<T>(this T result)
        {
            return new Result<T>(result);
        }

        public static Result<T> AuthenticationFailed<T>(this T result)
        {
            return new Result<T>(result)
            {
                StatusCode = HttpStatusCode.Unauthorized,
                IsSuccess = false,
                Errors = new List<Error>() { new Error("Credenciais incorretas.") }
            };
        }

        public static Result<T> ValidateResultBadRequest<T>(this T result, string message = null)
        {
            return new Result<T>(result)
            {
                StatusCode = HttpStatusCode.BadRequest,
                IsSuccess = false,
                Errors = new List<Error>() { new Error(message) }
            };
        }
    }
}
