using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Pazaar.Startup
{
    public static class ServiceCollectionExtensions
    {
        //public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        //    => services.AddDbContext<PazaarDbContext>(options => options
        //                .UseSqlServer(configuration.GetConnectionString()));

        public static IServiceCollection AddPasswordOptions(this IServiceCollection services)
        => services
                .Configure<IdentityOptions>(options =>
                {
                    options.Password.RequiredLength = 6;
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                });

        //public static IServiceCollection AddServices(this IServiceCollection services)
        //    => services
        //        .AddTransient<IUserService, UserService>()
        //        .AddSingleton<IDateTimeProvider, DateTimeProvider>();
    }
}
