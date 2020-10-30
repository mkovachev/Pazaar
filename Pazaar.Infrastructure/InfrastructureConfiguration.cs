using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
                .AddIdentity(configuration);

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
                                 .Assembly.FullName)));
            }

            services.AddScoped<IPazaarDbContext>(provider => provider.GetService<PazaarDbContext>());


            //services.AddIdentityServer()
            //    .AddApiAuthorization<User, PazaarDbContext>();

            services.AddTransient<IDateTime, DateTimeService>();
            //services.AddTransient<IIdentityService, IdentityService>();

            //services.AddAuthentication().AddIdentityServerJwt();

            //services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AdValidator>());

            return services;
        }

        private static IServiceCollection AddIdentity(
           this IServiceCollection services,
           IConfiguration configuration)
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

            //var secret = configuration
            //    .GetSection(nameof(ApplicationSettings))
            //    .GetValue<string>(nameof(ApplicationSettings.Secret));

            //var key = Encoding.ASCII.GetBytes(secret);

            //services
            //    .AddAuthentication(authentication =>
            //    {
            //        authentication.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //        authentication.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //    })
            //    .AddJwtBearer(bearer =>
            //    {
            //        bearer.RequireHttpsMetadata = false;
            //        bearer.SaveToken = true;
            //        bearer.TokenValidationParameters = new TokenValidationParameters
            //        {
            //            ValidateIssuerSigningKey = true,
            //            IssuerSigningKey = new SymmetricSecurityKey(key),
            //            ValidateIssuer = false,
            //            ValidateAudience = false
            //        };
            //    });

            //services.AddTransient<IIdentityService, IdentityService>();
            //services.AddTransient<IJwtTokenGenerator, JwtTokenGeneratorService>();

            return services;
        }
    }
}
