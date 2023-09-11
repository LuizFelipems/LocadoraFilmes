using FluentValidation;
using LocadoraFilmes.Domain.Models;
using LocadoraFilmes.Domain.Resources;

namespace LocadoraFilmes.Domain.Validators
{
    public class LocacaoValidator : AbstractValidator<Locacao>
    {
        public LocacaoValidator()
        {
            RuleFor(a => a.Filmes)
                    .NotNull().WithMessage(DomainMessages.RequiredProperty);

            RuleFor(a => a.CpfCliente)
                    .NotNull().WithMessage(DomainMessages.RequiredProperty)
                    .NotEmpty().WithMessage(DomainMessages.RequiredProperty)
                    .MaximumLength(14).WithMessage(DomainMessages.PropertyMaxLength.Replace("{0}", "14"));

            RuleFor(a => a.DataLocacao)
                    .NotNull().WithMessage(DomainMessages.RequiredProperty);
        }
    }
}
