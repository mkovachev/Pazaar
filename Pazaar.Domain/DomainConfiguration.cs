using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Pazaar.Domain.Common;
using Pazaar.Domain.Factories;
using Pazaar.Domain.Models.Ads;
using System.Reflection;

namespace Pazaar.Domain
{
    public static class DomainConfiguration
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            services.Scan(scan => scan
                    .FromCallingAssembly()
                    .AddClasses(classes => classes
                        .AssignableTo(typeof(IFactory<>)))
                    .AsMatchingInterface()
                    .WithTransientLifetime())
                .AddTransient<IInitialAds, AdData>()
                .AddTransient<IInitialCategories, CategoryData>()
                .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
