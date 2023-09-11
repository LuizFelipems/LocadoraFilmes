

using LocadoraFilmes.Application.Commons.Commands;
using LocadoraFilmes.Application.Commons.Responses;
using LocadoraFilmes.Application.UseCases.Security.Responses;

namespace LocadoraFilmes.Application.UseCases.Security.Requests
{
    public record LoginUserCommand : CommandRequest<Response<LoginUserResponse>>
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
