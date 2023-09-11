using AutoMapper;
using LocadoraFilmes.Application.UseCases.Filmes.Responses;
using LocadoraFilmes.Application.UseCases.Locadoras.Responses;
using LocadoraFilmes.Application.UseCases.Security.Responses;
using LocadoraFilmes.Domain.Models;

namespace LocadoraFilmes.Application.AutoMapper
{
    public class DomainToResponseMap : Profile
    {
        public DomainToResponseMap()
        {
            CreateMap<Filme, FilmeResponse>()
                .ForMember(dest => dest.GeneroNome, opt => opt.MapFrom(src => src.Genero.Nome));
            CreateMap<Filme, DeleteFilmeResponse>();

            CreateMap<Locacao, LocacaoResponse>()
                .ForMember(dest => dest.Filmes, opt => opt.MapFrom(src => src.Filmes.Select(x => x.Filme)));

            CreateMap<User, LoginUserResponse>();
        }
    }
}
