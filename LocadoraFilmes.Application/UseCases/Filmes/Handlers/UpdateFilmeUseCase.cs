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
    public class UpdateFilmeUseCase : Handler, IRequestHandler<UpdateFilmeCommand, Response<FilmeResponse>>
    {
        private readonly IFilmeRepository _filmeRepository;

        public UpdateFilmeUseCase(IUnitOfWork uow,
            IMapper mapper,
            IFilmeRepository filmeRepository,
            IServiceProvider services)
            : base(uow, mapper, services)
        {
            _filmeRepository = filmeRepository;
        }

        public async Task<Response<FilmeResponse>> Handle(UpdateFilmeCommand command, CancellationToken cancellationToken)
        {
            var filme = await _filmeRepository.GetById(command.Id, cancellationToken);
            if (filme is null)
                return Fail<FilmeResponse>();

            _mapper.Map(command, filme);
            if (!await IsValidAsync(filme))
                return Fail<FilmeResponse>();

            _filmeRepository.Update(filme);
            if (!await CommitAsync(cancellationToken))
                return Fail<FilmeResponse>();

            var response = _mapper.Map<FilmeResponse>(filme);
            return Success(response);
        }
    }
}
