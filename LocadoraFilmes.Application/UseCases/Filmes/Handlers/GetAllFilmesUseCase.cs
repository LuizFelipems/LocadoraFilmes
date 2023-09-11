using AutoMapper;
using LocadoraFilmes.Application.Commons.Handlers;
using LocadoraFilmes.Application.Commons.Responses;
using LocadoraFilmes.Application.UseCases.Filmes.Requests;
using LocadoraFilmes.Application.UseCases.Filmes.Responses;
using LocadoraFilmes.Domain.Interfaces.Data;
using LocadoraFilmes.Domain.Interfaces.Data.Repositories;
using MediatR;

namespace LocadoraFilmes.Application.UseCases.Filmes.Handlers
{
    public class GetAllFilmesUseCase : Handler, IRequestHandler<GetAllFilmesQuery, Response<List<FilmeResponse>>>
    {
        private readonly IFilmeRepository _filmeRepository;

        public GetAllFilmesUseCase(IUnitOfWork uow,
            IMapper mapper,
            IFilmeRepository filmeRepository,
            IServiceProvider services)
            : base(uow, mapper, services)
        {
            _filmeRepository = filmeRepository;
        }

        public async Task<Response<List<FilmeResponse>>> Handle(GetAllFilmesQuery command, CancellationToken cancellationToken)
        {
            var filmes = await _filmeRepository.GetAll(cancellationToken);

            var response = _mapper.Map<List<FilmeResponse>>(filmes);

            return Success(response);
        }
    }
}
