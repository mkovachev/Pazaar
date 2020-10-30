using Microsoft.Extensions.DependencyInjection;
using Pazaar.Domain.Validations;
using FluentValidation.AspNetCore;

namespace Pazaar.Application
{
    public static class ApplicationConfiguration
    {
        public static IServiceCollection AddWebComponents(this IServiceCollection services)
        {
            services.AddMvcCore()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AdValidator>());

            return services;
        }
    }
}