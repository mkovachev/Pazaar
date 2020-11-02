using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;

namespace Pazaar.Infrastructure.Persistence
{
    internal class DbInitializer : IDbInitializer
    {
        private readonly PazaarDbContext db;
        private readonly ISeedData data;
        private readonly ILogger<DbInitializer> logger;

        public DbInitializer(PazaarDbContext db, ISeedData data, ILogger<DbInitializer> logger)
        {
            this.db = db;
            this.data = data;
            this.logger = logger;
        }

        public void Initialize()
        {
            try
            {
                this.db.Database.Migrate();

                this.data.SeedDefaultUser();
                this.data.SeedSampleData();
            }

            catch (Exception ex)
            {
                this.logger.LogError(ex.Message);

                throw;
            }
        }
    }
}

