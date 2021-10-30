using Condominio.Domain.Entities;
using FluentValidation;

namespace Condominio.Domain.Validations
{
    public class CondominiumValidator : AbstractValidator<Condominium>
    {
        public CondominiumValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("O nome deve ser informado");
        }
    }
}
