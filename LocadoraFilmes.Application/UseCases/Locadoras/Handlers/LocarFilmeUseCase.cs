using AutoMapper;
using LocadoraFilmes.Application.Commons.Handlers;
using LocadoraFilmes.Application.Commons.Responses;
using LocadoraFilmes.Domain.Interfaces.Data.Repositories;
using LocadoraFilmes.Domain.Interfaces.Data;
using MediatR;
using LocadoraFilmes.Application.UseCases.Locadoras.Requests;
using LocadoraFilmes.Application.UseCases.Locadoras.Responses;
using LocadoraFilmes.Domain.Models;
using FluentValidation;
using LocadoraFilmes.Application.UseCases.Filmes.Responses;

namespace LocadoraFilmes.Application.UseCases.Locadoras.Handlers
{
    public class LocarFilmeUseCase : Handler, IRequestHandler<LocarFilmeCommand, Response<LocacaoResponse>>
    {
        private readonly IFilmeRepository _filmeRepository;
        private readonly ILocacaoRepository _locacaoRepository;

        public LocarFilmeUseCase(IUnitOfWork uow, 
            IMapper mapper, 
            IFilmeRepository filmeRepository, 
            ILocacaoRepository locacaoRepository,
            IServiceProvider services)
            : base(uow, mapper, services)
        {
            _filmeRepository = filmeRepository;
            _locacaoRepository = locacaoRepository;
        }

        public async Task<Response<LocacaoResponse>> Handle(LocarFilmeCommand command, CancellationToken cancellationToken)
        {
            var filme = await _filmeRepository.GetById(command.FilmeId, cancellationToken);
            if (filme is null)
                return Fail<LocacaoResponse>();

            var locacao = _mapper.Map<Locacao>(command);
            if (!await IsValidAsync(locacao))
                return Fail<LocacaoResponse>();

            locacao.LocarFilme(filme.Id);
            await _locacaoRepository.Add(locacao, cancellationToken);

            if (!await CommitAsync(cancellationToken))
                return Fail<LocacaoResponse>();

            var response = _mapper.Map<LocacaoResponse>(locacao);
            return Success(response);
        }
    }
}
