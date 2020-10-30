﻿using Microsoft.Extensions.DependencyInjection;
using Pazaar.Domain.Validations;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;

namespace Pazaar.Application
{
    public static class ApplicationConfiguration
    {
        public static IServiceCollection AddApplication(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddMvcCore()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AdValidator>());

            return services;
        }
    }
}