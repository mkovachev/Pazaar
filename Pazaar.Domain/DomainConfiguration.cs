using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Pazaar.Domain.Common;
using Pazaar.Domain.Factories;
using Pazaar.Domain.Models.Ads;
using Pazaar.Domain.Validations;

namespace Pazaar.Domain
{
    public static class DomainConfiguration
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            services
                .Scan(scan => scan
                    .FromCallingAssembly()
                    .AddClasses(classes => classes
                        .AssignableTo(typeof(IFactory)))
                    .AsMatchingInterface()
                    .WithTransientLifetime())
                .AddTransient<IInitialAds, AdData>()
                .AddTransient<IInitialCategories, CategoryData>();

            services.AddMvcCore().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AdValidator>());

            return services;
        }
    }
}
