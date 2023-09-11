using LocadoraFilmes.Api.Configurations;
using LocadoraFilmes.Api.Endpoints;
using LocadoraFilmes.Infra.CrossCutting.IoC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.RegisterServices(builder.Configuration);
builder.Services.ConfigureStartupApi(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseApiConfiguration();

app.MapSecurityEndpoints();
app.MapFilmeEndpoints();
app.MapLocacaoEndpoints();

app.Run();
