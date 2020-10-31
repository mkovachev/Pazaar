using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Pazaar.Infrastructure.Persistence
{
    internal class DbInitializer : IDbInitializer
    {
        private readonly PazaarDbContext db;
        //private readonly ILogger logger;
        private readonly ISeedData data;

        public DbInitializer(PazaarDbContext db, ISeedData data)
        {
            this.db = db;
            //this.logger = logger;
            this.data = data;
        }

        public async Task Initialize()
        {
            try
            {
                this.db.Database.Migrate();

                if (db.Database.IsSqlServer())
                {
                    db.Database.Migrate();
                }

                await this.data.SeedDefaultUser();
                await this.data.SeedSampleData();
            }
            catch (Exception ex)
            {
                //this.logger.LogError(ex, "An error occurred while migrating or seeding the database.");

                throw;
            }
        }
    }
}

