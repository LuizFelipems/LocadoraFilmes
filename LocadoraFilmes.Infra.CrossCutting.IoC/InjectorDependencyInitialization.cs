using LocadoraFilmes.Application;
using LocadoraFilmes.Domain.Interfaces.Data;
using LocadoraFilmes.Domain.Interfaces.Data.Repositories;
using LocadoraFilmes.Infra.Data.DataContexts;
using LocadoraFilmes.Infra.Data.Repositories;
using LocadoraFilmes.Infra.Data.UoW;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LocadoraFilmes.Infra.CrossCutting.IoC
{
    public static class InjectorDependencyInitialization
    {
        public static void RegisterServices(this IServiceCollection services, ConfigurationManager configuration)
        {
            RegisterDataAccess(services);
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(Pin).Assembly));
        }

        private static void RegisterDataAccess(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IFilmeRepository, FilmeRepository>();
            services.AddScoped<ILocacaoRepository, LocacaoRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
