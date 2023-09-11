using AutoMapper;
using LocadoraFilmes.Application.UseCases.Filmes.Requests;
using LocadoraFilmes.Application.UseCases.Locadoras.Requests;
using LocadoraFilmes.Domain.Models;

namespace LocadoraFilmes.Application.AutoMapper
{
    public class RequestToDomainMap : Profile
    {
        public RequestToDomainMap()
        {
            CreateMap<CreateFilmeCommand, Filme>();
            CreateMap<UpdateFilmeCommand, Filme>();

            CreateMap<LocarFilmeCommand, Locacao>();
        }
    }
}
