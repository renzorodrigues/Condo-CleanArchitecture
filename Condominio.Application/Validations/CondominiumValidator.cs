using Condominio.Application.Products.Commands.Requests;
using FluentValidation;

namespace Condominio.Application.Validations
{
    public class CondominiumValidator : AbstractValidator<CreateCondominiumCommand>
    {
        public CondominiumValidator()
        {
            
            RuleFor(x => x.Name).NotEmpty().WithMessage("O nome deve ser informado");
        }
    }
}
