using MediatR;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pazaar.Application.Features.Ads;
using Pazaar.Domain.Factories.Ads;

namespace Pazaar.Startup
{
    public class TestStartup : Startup
    {
        public TestStartup(IConfiguration configuration)
            : base(configuration)
        {
        }

        public void ConfigureTestServices(IServiceCollection services)
        {
            base.ConfigureServices(services);

            ValidateServices(services);

            //services.ReplaceTransient<UserManager<User>>(_ => IdentityFakes.FakeUserManager);
            //services.ReplaceTransient<IJwtTokenGenerator>(_ => JwtTokenGeneratorFakes.FakeJwtTokenGenerator);*/
        }

        private static void ValidateServices(IServiceCollection services)
        {
            var provider = services.BuildServiceProvider();

            provider.GetRequiredService<IAdFactory>();
            provider.GetRequiredService<IMediator>();
            provider.GetRequiredService<IAdRepository>();
            provider.GetRequiredService<IControllerFactory>();
        }
    }
}
