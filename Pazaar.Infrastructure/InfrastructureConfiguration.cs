﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pazaar.Application.Identity;
using Pazaar.Application.Interfaces;
using Pazaar.Infrastructure.Identity;
using Pazaar.Infrastructure.Persistence;
using Pazaar.Infrastructure.Services;


namespace Pazaar.Infrastructure
{
    public static class InfrastructureConfiguration
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
            => services
                .AddDatabase(configuration)
                .AddIdentity();

        private static IServiceCollection AddDatabase(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<PazaarDbContext>(options =>
                    options.UseInMemoryDatabase("TestDb"));
            }

            else
            {
                services.AddDbContext<PazaarDbContext>(options => options
                    .UseSqlServer(configuration.GetConnectionString("DefaultConnection"), sqlServer => sqlServer.MigrationsAssembly(typeof(PazaarDbContext)
                                 .Assembly.FullName)))
                    .AddTransient<IDbInitializer, DbInitializer>();
            }

            services.AddScoped<IPazaarDbContext>(provider => provider.GetService<PazaarDbContext>());

            services.AddDefaultIdentity<User>()
                .AddEntityFrameworkStores<PazaarDbContext>();

            services.AddTransient<IDateTime, DateTimeService>();
            services.AddTransient<IIdentity, IdentityService>();

            services.AddAuthentication()
                    .AddIdentityServerJwt();

            return services;
        }

        private static IServiceCollection AddIdentity(
           this IServiceCollection services)
        {
            services
                .AddIdentity<User, IdentityRole>(options =>
                {
                    options.Password.RequiredLength = 6;
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                })
                .AddEntityFrameworkStores<PazaarDbContext>();

            return services;
        }
    }
}
