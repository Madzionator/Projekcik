using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Projekcik.Core.Services;
using Projekcik.Database;

namespace Projekcik.Core
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddProjekcikCore(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDatabase(configuration.GetConnectionString("db"));

            services.AddScoped<IHashService, HashService>();
            services.AddScoped<ITokenManager, TokenManager>();
            services.AddTransient<IUserInfo, UserInfo>();
            services.AddTransient<IUserService, UserService>();

            return services;
        }
    }
}