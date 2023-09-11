using LocadoraFilmes.Application.Commons.Responses;
using LocadoraFilmes.Application.UseCases.Filmes.Requests;
using LocadoraFilmes.Application.UseCases.Filmes.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LocadoraFilmes.Api.Endpoints
{
    public static class FilmeEndpoints
    {
        public static void MapFilmeEndpoints(this WebApplication app)
        {
            app.MapPost("/v1/filme", CreateFilme)
               .WithTags("Filme")
               .ProducesProblem(400)
               .ProducesProblem(401)
               .ProducesProblem(404)
               .RequireAuthorization()
               .Produces<Response<FilmeResponse>>(201)
               .WithMetadata(new SwaggerOperationAttribute("Create New Filme"));

            app.MapPut("/v1/filme/{id}", UpdateFilme)
               .WithTags("Filme")
               .ProducesProblem(400)
               .ProducesProblem(401)
               .ProducesProblem(404)
               .RequireAuthorization()
               .Produces<Response<FilmeResponse>>(201)
               .WithMetadata(new SwaggerOperationAttribute("Update Filme"));

            app.MapGet("/v1/filmes", GetAllFilmes)
               .WithTags("Filme")
               .ProducesProblem(400)
               .ProducesProblem(401)
               .ProducesProblem(404)
               .RequireAuthorization()
               .Produces<Response<List<FilmeResponse>>>(200)
               .WithMetadata(new SwaggerOperationAttribute("Get All Filmes"));

            app.MapGet("/v1/filme/{id}", GetByIdFilme)
               .WithTags("Filme")
               .ProducesProblem(400)
               .ProducesProblem(401)
               .ProducesProblem(404)
               .RequireAuthorization()
               .Produces<Response<FilmeResponse>>(200)
               .WithMetadata(new SwaggerOperationAttribute("Get Filme By Id"));

            app.MapDelete("/v1/filme/{id}", DeleteFilme)
               .WithTags("Filme")
               .ProducesProblem(400)
               .ProducesProblem(401)
               .ProducesProblem(404)
               .RequireAuthorization()
               .Produces<Response<DeleteFilmeResponse>>(200)
               .WithMetadata(new SwaggerOperationAttribute("Delete Filme By Id"));

            app.MapDelete("/v1/filmes", DeleteFilmes)
               .WithTags("Filme")
               .ProducesProblem(400)
               .ProducesProblem(401)
               .ProducesProblem(404)
               .RequireAuthorization()
               .Produces<Response<List<DeleteFilmeResponse>>>(200)
               .WithMetadata(new SwaggerOperationAttribute("Delete Filmes By Ids"));
        }

        public static async Task<IResult> CreateFilme([FromServices] IMediator _mediator, [FromBody] CreateFilmeCommand command)
        {
            var response = await _mediator.Send(command);

            return response.IsValid? Results.Created($"/v1/filme/{response?.Data?.Id}", response)
                                    : Results.BadRequest(response.MessageResults);
        }
        
        public static async Task<IResult> UpdateFilme([FromServices] IMediator _mediator, Guid id, [FromBody] UpdateFilmeCommand command)
        {
            var response = await _mediator.Send(command.AssignId(id));

            return response.IsValid? Results.Created($"/v1/filme/{response?.Data?.Id}", response)
                                    : Results.BadRequest(response.MessageResults);
        }
        
        public static async Task<Response<List<FilmeResponse>>> GetAllFilmes([FromServices] IMediator _mediator)
        {
            return await _mediator.Send(new GetAllFilmesQuery());
        }
        
        public static async Task<Response<FilmeResponse>> GetByIdFilme([FromServices] IMediator _mediator, [FromRoute] Guid id)
        {
            return await _mediator.Send(new GetByIdFilmeQuery(id));
        }
        
        public static async Task<Response<DeleteFilmeResponse>> DeleteFilme([FromServices] IMediator _mediator, [FromRoute] Guid id)
        {
            return await _mediator.Send(new DeleteFilmeCommand() { Id = id });
        }
        
        public static async Task<Response<List<DeleteFilmeResponse>>> DeleteFilmes([FromServices] IMediator _mediator, [FromBody] DeleteFilmesCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
