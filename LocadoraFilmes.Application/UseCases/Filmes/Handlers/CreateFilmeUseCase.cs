using AutoMapper;
using LocadoraFilmes.Application.Commons.Handlers;
using LocadoraFilmes.Application.Commons.Responses;
using LocadoraFilmes.Application.UseCases.Filmes.Requests;
using LocadoraFilmes.Application.UseCases.Filmes.Responses;
using LocadoraFilmes.Domain.Interfaces.Data;
using LocadoraFilmes.Domain.Interfaces.Data.Repositories;
using LocadoraFilmes.Domain.Models;
using MediatR;

namespace LocadoraFilmes.Application.UseCases.Filmes.Handlers
{
    public class CreateFilmeUseCase : Handler, IRequestHandler<CreateFilmeCommand, Response<FilmeResponse>>
    {
        private readonly IFilmeRepository _filmeRepository;

        public CreateFilmeUseCase(IUnitOfWork uow, 
            IMapper mapper, 
            IFilmeRepository filmeRepository,
            IServiceProvider services)
            : base(uow, mapper, services)
        {
            _filmeRepository = filmeRepository;
        }

        public async Task<Response<FilmeResponse>> Handle(CreateFilmeCommand command, CancellationToken cancellationToken)
        {
            var filme = _mapper.Map<Filme>(command);
            if (!await IsValidAsync(filme))
                return Fail<FilmeResponse>();

            await _filmeRepository.Add(filme, cancellationToken);

            if (!await CommitAsync(cancellationToken))
                return Fail<FilmeResponse>();

            var response = _mapper.Map<FilmeResponse>(filme);
            return Success(response);
        }
    }
}
