using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Pazaar.Infrastructure.Persistence;

namespace Pazaar.Startup
{
    public static class ApplicationInitialization
    {
        public static IApplicationBuilder Initialize(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();

            var initializers = serviceScope.ServiceProvider.GetServices<IDbInitializer>();

            foreach (var initializer in initializers)
            {
                initializer.Initialize();
            }

            return app;
        }
    }
}
