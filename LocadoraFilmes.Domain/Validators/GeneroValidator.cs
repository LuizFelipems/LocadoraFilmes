using FluentValidation;
using LocadoraFilmes.Domain.Models;
using LocadoraFilmes.Domain.Resources;

namespace LocadoraFilmes.Domain.Validators
{
    public class GeneroValidator : AbstractValidator<Genero>
    {
        public GeneroValidator()
        {
            RuleFor(a => a.Nome)
                    .NotNull().WithMessage(DomainMessages.RequiredProperty)
                    .NotEmpty().WithMessage(DomainMessages.RequiredProperty)
                    .MaximumLength(100).WithMessage(DomainMessages.PropertyMaxLength.Replace("{0}", "100"));
        }
    }
}
