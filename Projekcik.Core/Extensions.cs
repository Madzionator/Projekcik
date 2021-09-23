using Microsoft.Extensions.DependencyInjection;
using Projekcik.Core.Services;
using Projekcik.Core.Utils;
using Projekcik.Database;
using Projekcik.Infrastructure.SqlServer;

namespace Projekcik.Core
{
    public static class Extensions
    {
        public static IServiceCollection AddProjekcikCore(this IServiceCollection services)
        {
            services.AddSqlServer<DataContext>();

            services.AddScoped<IHashService, HashService>();
            services.AddTransient<IUserInfo, UserInfo>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IJobService, JobService>();
            services.AddScoped<ILocationService, LocationService>();
            services.AddScoped<ICandidateService, CandidateService>();

            services.AddAutoMapper(typeof(Extensions).Assembly);

            return services;
        }
    }
}