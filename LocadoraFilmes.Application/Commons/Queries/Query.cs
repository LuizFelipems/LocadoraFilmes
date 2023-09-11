using MediatR;

namespace LocadoraFilmes.Application.Commons.Queries
{
    public record Query<TResponse> : IRequest<TResponse>
    {
    }
}
