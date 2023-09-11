using MediatR;

namespace LocadoraFilmes.Application.Commons.Commands
{
    public abstract record CommandRequest<TResponse> : IRequest<TResponse>
    {
    }
}
