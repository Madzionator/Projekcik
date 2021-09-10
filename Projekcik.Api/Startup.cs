using System;
using FluentValidation.AspNetCore;
using MicroElements.Swashbuckle.FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Projekcik.Core;
using Projekcik.Core.DTO;
using Projekcik.Infrastructure;
using Projekcik.Infrastructure.SqlServer;

namespace Projekcik.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddInfrastructure();
            services.AddSqlServer();
            services.AddProjekcikCore();

            services.AddControllers().AddFluentValidation(fv =>
            {
                fv.RegisterValidatorsFromAssemblyContaining<UserDtoValidator>();
                fv.ValidatorFactoryType = typeof(HttpContextServiceProviderValidatorFactory);
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseInfrastructure();
         
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/", context => context.Response.WriteAsync($"Dziczkowe API {DateTime.Now:R}"));
            });
        }
    }
}