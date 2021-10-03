using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Projekcik.Infrastructure.SqlServer
{
    public static class Extensions
    {

        public static IServiceCollection AddSqlServer(this IServiceCollection services)
        {
            var options = services.GetOptions<SqlServerOptions>("SqlServer");
            services.AddSingleton(options);
            
            return services;
        }

        public static IServiceCollection AddSqlServer<T>(this IServiceCollection services) where T : DbContext
        {
            var options = services.GetOptions<SqlServerOptions>("SqlServer");
            services.AddDbContext<T>(x =>
            {
#if DEBUG
                x.UseLoggerFactory(LoggerFactory.Create(b => b.AddConsole()));
                x.EnableSensitiveDataLogging();
#endif
                x.UseSqlServer(options.ConnectionString);
            });
            
            return services;
        }
    }
}