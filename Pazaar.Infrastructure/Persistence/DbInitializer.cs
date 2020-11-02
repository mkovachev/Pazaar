using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Pazaar.Infrastructure.Persistence
{
    internal class DbInitializer : IDbInitializer
    {
        private readonly PazaarDbContext db;
        private readonly ILogger<DbInitializer> logger;
        private readonly ISeedData data;

        public DbInitializer(PazaarDbContext db, ISeedData data, ILogger<DbInitializer> logger)
        {
            this.db = db;
            this.logger = logger;
            this.data = data;
            this.logger = logger;
        }

        public async Task Initialize()
        {
            try
            {
                this.db.Database.Migrate();

                await this.data.SeedDefaultUser();
                await this.data.SeedSampleData();

                await this.db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex.Message);

                throw;
            }
        }
    }
}

