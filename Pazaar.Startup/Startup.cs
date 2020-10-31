using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Pazaar.Application;
using Pazaar.Domain;
using Pazaar.Infrastructure;
using Pazaar.Web;

namespace Pazaar.Startup
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddDomain()
                .AddApplication(this.Configuration)
                .AddInfrastructure(this.Configuration)
                .AddWeb();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Pazaar.Startup", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pazaar.Startup v1"));
            }

            app
               //.UseValidationExceptionHandler()
               .UseHttpsRedirection()
               .UseRouting()
               .UseCors(options => options
                                    .AllowAnyOrigin()
                                    .AllowAnyHeader()
                                    .AllowAnyMethod())
               .UseAuthentication()
               .UseAuthorization()
               .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                    endpoints.MapHealthChecks("/health")
                             .RequireAuthorization();
                })
               .Initialize();
        }
    }
}
