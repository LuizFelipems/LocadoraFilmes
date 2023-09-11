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
    public class DeleteFilmesUseCase : Handler, IRequestHandler<DeleteFilmesCommand, Response<List<DeleteFilmeResponse>>>
    {
        private readonly IFilmeRepository _filmeRepository;

        public DeleteFilmesUseCase(IUnitOfWork uow,
            IMapper mapper,
            IFilmeRepository filmeRepository,
            IServiceProvider services)
            : base(uow, mapper, services)
        {
            _filmeRepository = filmeRepository;
        }

        public async Task<Response<List<DeleteFilmeResponse>>> Handle(DeleteFilmesCommand command, CancellationToken cancellationToken)
        {
            var filmes = command.GenerateFilmes();
            _filmeRepository.RemoveRange(filmes, cancellationToken);

            if (!await CommitAsync(cancellationToken))
                return Fail<List<DeleteFilmeResponse>>();

            var response = _mapper.Map<List<DeleteFilmeResponse>>(filmes);
            return Success(response);
        }
    }
}
