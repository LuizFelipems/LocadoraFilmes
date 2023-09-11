using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LocadoraFilmes.Infra.Data.DataContexts
{
    public static class ContextConfiguration
    {
        public static IApplicationBuilder UpdateDatabase(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices
                .GetService<IServiceScopeFactory>()?
                .CreateScope();

            using var context = serviceScope?.ServiceProvider.GetService<AppDbContext>();
            context?.Database.Migrate();

            return app;
        }
    }
}
