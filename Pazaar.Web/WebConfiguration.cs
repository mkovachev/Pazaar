using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Pazaar.Application.Interfaces;
using Pazaar.Web.Services;

namespace Pazaar.Web
{
    public static class WebConfiguration
    {
        public static IServiceCollection AddWeb(this IServiceCollection services)
        {
            services
                .AddSingleton<ICurrentUserId, CurrentUserService>()
                .AddHttpContextAccessor()
                .AddControllers()
                .AddNewtonsoftJson();

            services.AddHealthChecks();


            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            return services;
        }
    }
}
