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

        public static Result<T> ValidateResultCreate<T>(this T guid)
        {
            return new Result<T>(guid)
            {
                StatusCode = HttpStatusCode.Created
            };
        }

        public static Result<IEnumerable<T>> ValidateResultGetAll<T>(this IEnumerable<T> result)
        {
            if (result.Any())
                return new Result<IEnumerable<T>>(result);
            
            return new Result<IEnumerable<T>>(result)
            {
                Errors = new List<Error>() { new Error("A lista está vazia") }
            };
        }

        public static Result<T> ValidateResultAuthentication<T>(this T result)
        {
            if (result is null)
            {
                return new Result<T>(result)
                {
                    StatusCode = HttpStatusCode.Unauthorized,
                    IsSuccess = false,
                    Errors = new List<Error>() { new Error("Email e/ou senha incorretos.") }
                };
            }

            return new Result<T>(result);
        }
    }
}
