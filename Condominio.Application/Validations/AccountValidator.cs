using FluentValidation;
using Condominio.Core.Extensions;

namespace Condominio.Application.Validations
{
    //public class AccountValidator : AbstractValidator<CreateApplicationUserCommand>
    //{
    //    public AccountValidator()
    //    {
    //        RuleFor(x => x.Email)
    //            .NotEmpty().WithMessage("O email deve ser informado.")
    //            .Must(x => x.Email()).WithMessage("O e-mail deve conter um formato válido");

    //        RuleFor(x => x.Password)
    //            .NotEmpty().WithMessage("A senha deve ser informada.")
    //            .Must(x => x.PasswordHasNumber()).WithMessage("A senha deve conter números.")
    //            .Must(x => x.PasswordHasUpperChar()).WithMessage("A senha deve conter letras maiúsculas.")
    //            .Must(x => x.PasswordHasLowerChar()).WithMessage("A senha deve conter letras minúsculas.")
    //            .Must(x => x.PasswordHasMinimum8Chars()).WithMessage("A senha deve conter o mínimo de 8 caracteres.")
    //            .MaximumLength(30).WithMessage("A senha deve conter o máximo de 30 caracteres");
    //    }
    //}
}
