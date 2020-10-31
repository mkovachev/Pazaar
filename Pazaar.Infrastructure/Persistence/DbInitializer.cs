using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Pazaar.Infrastructure.Identity;
using System;
using System.Threading.Tasks;

namespace Pazaar.Infrastructure.Persistence
{
    internal class DbInitializer : IDbInitializer
    {
        private readonly PazaarDbContext context;
        private readonly UserManager<User> userManager;
        private readonly ILogger logger;

        public DbInitializer(PazaarDbContext context, UserManager<User> userManager, ILogger logger)
        {
            this.context = context;
            this.userManager = userManager;
            this.logger = logger;
        }

        public async Task Initialize()
        {
            try
            {
                this.context.Database.Migrate();

                if (context.Database.IsSqlServer())
                {
                    context.Database.Migrate();
                }

                await PazaarDbContextSeed.SeedDefaultUser(userManager);
                await PazaarDbContextSeed.SeedSampleData(context);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, "An error occurred while migrating or seeding the database.");

                throw;
            }
        }
    }
}

