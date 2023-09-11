using FluentValidation.AspNetCore;
using LocadoraFilmes.Application;
using LocadoraFilmes.Application.AutoMapper;
using LocadoraFilmes.Application.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Security.Claims;
using System.Text;
using LocadoraFilmes.Infra.Data.DataContexts;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using FluentValidation;
using LocadoraFilmes.Domain.Models;
using Microsoft.AspNetCore.Identity;
using LocadoraFilmes.Domain.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace LocadoraFilmes.Api.Configurations
{
    public static class ApiConfig
    {
        public static IServiceCollection ConfigureStartupApi(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));

            services.AddCorsSetup()
                    .AddFluentValidationSetup()
                    .AddSwaggerDocumentation()
                    .AddSecurity(configuration)
                    .AddAutoMapperSetup();

            return services;
        }

        public static void UseApiConfiguration(this IApplicationBuilder app)
        {
            app.UpdateDatabase()
               .UseSwaggerDocumentation()
               .UseHttpsRedirection()
               .UseCors("All")
               .UseSecurity();
        }

        #region ConfigureStartupApi
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            var securityScheme = new OpenApiSecurityScheme()
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "JSON Web Token based security",
            };

            var securityReq = new OpenApiSecurityRequirement()
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] {}
                }
            };

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(x =>
            {
                x.AddSecurityDefinition("Bearer", securityScheme);
                x.AddSecurityRequirement(securityReq);
                x.EnableAnnotations();
            });

            return services;
        }
        
        public static IServiceCollection AddFluentValidationSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddFluentValidationAutoValidation()
                    .AddFluentValidationClientsideAdapters()
                    .AddValidatorsFromAssemblyContaining<Pin>(ServiceLifetime.Transient);

            services.AddTransient<IValidator<Filme>, FilmeValidator>();
            services.AddTransient<IValidator<Genero>, GeneroValidator>();
            services.AddTransient<IValidator<Locacao>, LocacaoValidator>();

            services.AddSingleton(new JsonSerializer
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                }
            });
            return services;
        }
        
        public static IServiceCollection AddCorsSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddCors(options =>
            {
                options.AddPolicy("All",
                    builder =>
                        builder
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader());
            });

            return services;
        }

        public static IServiceCollection AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(Pin));
            AutoMapperConfig.RegisterMappings();

            return services;
        }

        private static IServiceCollection AddSecurity(this IServiceCollection services, IConfiguration configuration)
        {
            var key = Encoding.ASCII.GetBytes(configuration.GetValue<string>("SecretKey"));
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("user", policy => policy.RequireClaim(ClaimTypes.Role, "user"));
                options.AddPolicy("admin", policy => policy.RequireClaim(ClaimTypes.Role, "admin"));
            });

            services.AddTransient<TokenService>();

            return services;
        }
        #endregion

        #region UseApiConfiguration
        private static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();

            return app;
        }

        private static IApplicationBuilder UseSecurity(this IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.UseAuthorization();
            return app;
        }
        #endregion
    }
}
