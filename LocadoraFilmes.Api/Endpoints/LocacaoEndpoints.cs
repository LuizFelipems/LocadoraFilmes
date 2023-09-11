using LocadoraFilmes.Application.Commons.Responses;
using LocadoraFilmes.Application.UseCases.Locadoras.Requests;
using LocadoraFilmes.Application.UseCases.Locadoras.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LocadoraFilmes.Api.Endpoints
{
    public static class LocacaoEndpoints
    {
        public static void MapLocacaoEndpoints(this WebApplication app)
        {
            app.MapPut("/v1/locar/{filmeId}", LocarFilme)
               .WithTags("Locacao")
               .ProducesProblem(400)
               .ProducesProblem(401)
               .ProducesProblem(404)
               .RequireAuthorization()
               .Produces<Response<LocacaoResponse>>(204)
               .WithMetadata(new SwaggerOperationAttribute("Locar Filme"));

            app.MapGet("/v1/locacoes", GetAllLocacoes)
               .WithTags("Locacao")
               .ProducesProblem(400)
               .ProducesProblem(401)
               .ProducesProblem(404)
               .RequireAuthorization()
               .Produces<Response<List<LocacaoResponse>>>(200)
               .WithMetadata(new SwaggerOperationAttribute("Get All Locacoes"));
        }

        public static async Task<Response<LocacaoResponse>> LocarFilme([FromServices] IMediator _mediator, Guid filmeId, [FromBody] LocarFilmeCommand command)
        {
            return await _mediator.Send(command.AssignFilmeId(filmeId));
        }

        public static async Task<Response<List<LocacaoResponse>>> GetAllLocacoes([FromServices] IMediator _mediator)
        {
            return await _mediator.Send(new GetAllLocacoesQuery());
        }
    }
}
