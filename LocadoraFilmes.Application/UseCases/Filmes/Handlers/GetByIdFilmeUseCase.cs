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
    internal class GetByIdFilmeUseCase : Handler, IRequestHandler<GetByIdFilmeQuery, Response<FilmeResponse>>
    {
        private readonly IFilmeRepository _filmeRepository;

        public GetByIdFilmeUseCase(IUnitOfWork uow,
            IMapper mapper,
            IFilmeRepository filmeRepository,
            IServiceProvider services)
            : base(uow, mapper, services)
        {
            _filmeRepository = filmeRepository;
        }

        public async Task<Response<FilmeResponse>> Handle(GetByIdFilmeQuery query, CancellationToken cancellationToken)
        {
            var filme = await _filmeRepository.GetById(query.Id, cancellationToken);

            var response = _mapper.Map<FilmeResponse>(filme);

            return Success(response);
        }
    }
}
