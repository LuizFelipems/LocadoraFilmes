using LocadoraFilmes.Application.Commons.Responses;
using LocadoraFilmes.Application.UseCases.Security.Requests;
using LocadoraFilmes.Application.UseCases.Security.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LocadoraFilmes.Api.Endpoints
{
    public static class SecurityEndpoints
    {
        public static void MapSecurityEndpoints(this WebApplication app)
        {
            app.MapPost("/v1/login", LoginUser)
               .WithTags("Security")
               .ProducesProblem(404)
               .AllowAnonymous()
               .Produces<Response<LoginUserResponse>>(201)
               .WithMetadata(new SwaggerOperationAttribute("Login User"));
        }

        public static async Task<Response<LoginUserResponse>> LoginUser([FromServices] IMediator _mediator, [FromBody] LoginUserCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
