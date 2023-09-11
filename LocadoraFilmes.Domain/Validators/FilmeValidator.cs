﻿using FluentValidation;
using LocadoraFilmes.Domain.Models;
using LocadoraFilmes.Domain.Resources;

namespace LocadoraFilmes.Domain.Validators
{
    public class FilmeValidator : AbstractValidator<Filme>
    {
        public FilmeValidator()
        {
            RuleFor(a => a.Nome)
                    .NotNull().WithMessage(DomainMessages.RequiredProperty)
                    .NotEmpty().WithMessage(DomainMessages.RequiredProperty)
                    .MaximumLength(200).WithMessage(DomainMessages.PropertyMaxLength.Replace("{0}", "200"));

            RuleFor(a => a.Genero).SetValidator(new GeneroValidator());
        }
    }
}
