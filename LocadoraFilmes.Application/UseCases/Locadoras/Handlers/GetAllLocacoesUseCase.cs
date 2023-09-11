using AutoMapper;
using LocadoraFilmes.Application.Commons.Handlers;
using LocadoraFilmes.Application.Commons.Responses;
using LocadoraFilmes.Domain.Interfaces.Data.Repositories;
using LocadoraFilmes.Domain.Interfaces.Data;
using MediatR;
using LocadoraFilmes.Application.UseCases.Locadoras.Responses;
using LocadoraFilmes.Application.UseCases.Locadoras.Requests;

namespace LocadoraFilmes.Application.UseCases.Locadoras.Handlers
{
    public class GetAllLocacoesUseCase : Handler, IRequestHandler<GetAllLocacoesQuery, Response<List<LocacaoResponse>>>
    {
        private readonly ILocacaoRepository _locacaoRepository;

        public GetAllLocacoesUseCase(IUnitOfWork uow,
            IMapper mapper,
            ILocacaoRepository locacaoRepository,
            IServiceProvider services)
            : base(uow, mapper, services)
        {
            _locacaoRepository = locacaoRepository;
        }

        public async Task<Response<List<LocacaoResponse>>> Handle(GetAllLocacoesQuery command, CancellationToken cancellationToken)
        {
            var locacoes = await _locacaoRepository.GetAll(cancellationToken);

            var response = _mapper.Map<List<LocacaoResponse>>(locacoes);

            return Success(response);
        }
    }
}
