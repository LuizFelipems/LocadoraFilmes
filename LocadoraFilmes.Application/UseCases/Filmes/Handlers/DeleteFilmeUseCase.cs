using AutoMapper;
using FluentValidation.Results;
using LocadoraFilmes.Application.Commons.Handlers;
using LocadoraFilmes.Application.Commons.Responses;
using LocadoraFilmes.Application.UseCases.Filmes.Requests;
using LocadoraFilmes.Application.UseCases.Filmes.Responses;
using LocadoraFilmes.Domain.Interfaces.Data;
using LocadoraFilmes.Domain.Interfaces.Data.Repositories;
using MediatR;

namespace LocadoraFilmes.Application.UseCases.Filmes.Handlers
{
    public class DeleteFilmeUseCase : Handler, IRequestHandler<DeleteFilmeCommand, Response<DeleteFilmeResponse>>
    {
        private readonly IFilmeRepository _filmeRepository;

        public DeleteFilmeUseCase(IUnitOfWork uow,
            IMapper mapper,
            IFilmeRepository filmeRepository,
            IServiceProvider services)
            : base(uow, mapper, services)
        {
            _filmeRepository = filmeRepository;
        }

        public async Task<Response<DeleteFilmeResponse>> Handle(DeleteFilmeCommand command, CancellationToken cancellationToken)
        {
            var filme = command.GenerateFilme();
            _filmeRepository.Remove(filme, cancellationToken);

            if (!await CommitAsync(cancellationToken))
                return Fail<DeleteFilmeResponse>();

            var response = _mapper.Map<DeleteFilmeResponse>(filme);
            return Success(response);
        }
    }
}
