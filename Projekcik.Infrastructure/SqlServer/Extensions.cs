using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

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
            services.AddDbContext<T>(x => x.UseSqlServer(options.ConnectionString));
            
            return services;
        }
    }
}