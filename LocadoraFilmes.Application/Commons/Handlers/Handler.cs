using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using LocadoraFilmes.Application.Commons.Responses;
using LocadoraFilmes.Application.Resources;
using LocadoraFilmes.Domain.Interfaces.Data;
using LocadoraFilmes.Domain.Models;
using Microsoft.Extensions.DependencyInjection;

namespace LocadoraFilmes.Application.Commons.Handlers
{
    public abstract class Handler
    {
        protected readonly IMapper _mapper;
        protected readonly IUnitOfWork _uow;
        private readonly IServiceProvider _services;

        public Handler(IUnitOfWork uow,
                        IMapper mapper,
                        IServiceProvider services)
        {
            _uow = uow;
            _mapper = mapper;
            _services = services;
        }

        protected ValidationResult ValidationResult { get; } = new ValidationResult();

        protected async Task<bool> IsValidAsync<TParameter>(TParameter target) where TParameter : Entity<TParameter>
        {
            var validator = _services.GetService<IValidator<TParameter>>();
            
            if (validator is null) 
                return false;

            var validationResult = await validator.ValidateAsync(target);

            foreach (var error in validationResult.Errors)
                ValidationResult.Errors.Add(error);

            return ValidationResult.IsValid;
        }

        protected async Task<bool> CommitAsync(CancellationToken cancellationToken = default)
        {
            if (_uow.HasChanges() && (await _uow.SaveAsync(cancellationToken) <= 0))
                AddError(ApplicationMessages.CommitErrorMessage);

            return ValidationResult.IsValid;
        }

        protected bool IsValid()
        {
            return ValidationResult.IsValid;
        }

        protected bool IsSuccess(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
                ValidationResult.Errors.Add(error);

            return ValidationResult.IsValid;
        }

        protected void AddError(string mensagem)
        {
            ValidationResult.Errors.Add(new ValidationFailure(string.Empty, mensagem));
        }

        protected Response<TData> Success<TData>(TData data)
        {
            return Response<TData>.Success(data, ValidationResult);
        }

        protected Response<TData> Fail<TData>()
        {
            return Response<TData>.Fail(ValidationResult);
        }
    }
}
