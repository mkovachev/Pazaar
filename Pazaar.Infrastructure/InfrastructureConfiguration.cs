using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pazaar.Infrastructure.Persistence;

namespace Pazaar.Infrastructure
{
    public static class InfrastructureConfiguration
    {
        private static IServiceCollection AddDatabase(
            this IServiceCollection services,
            IConfiguration configuration)
            => services
                .AddDbContext<PazaarDbContext>(options => options
                    .UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                        sqlServer => sqlServer
                            .MigrationsAssembly(typeof(PazaarDbContext)
                                .Assembly.FullName)));
    }
}
