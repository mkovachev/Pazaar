using Microsoft.AspNetCore.Identity;
using Pazaar.Domain.Common;
using Pazaar.Infrastructure.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace Pazaar.Infrastructure.Persistence
{
    public class SeedData : ISeedData
    {
        private readonly IInitialCategories categories;
        private readonly IInitialAds ads;
        private readonly PazaarDbContext db;
        private readonly UserManager<User> userManager;

        public SeedData(IInitialCategories categories, IInitialAds ads, PazaarDbContext db, UserManager<User> userManager)
        {
            this.categories = categories;
            this.ads = ads;
            this.db = db;
            this.userManager = userManager;
        }

        public async Task SeedDefaultUser()
        {
            var admin = new User("admin@mail.com");

            if (this.userManager.Users.All(u => u.UserName != admin.Email))
            {
                await this.userManager.CreateAsync(admin, "admin1234");
            }

            await this.db.SaveChangesAsync();
        }

        public async Task SeedSampleData()
        {
            var initialCategories = this.categories.GetInitialCategories();

            if (!this.db.Categories.Any())
            {
                await this.db.Categories.AddRangeAsync(initialCategories);
            }

            var initialAds = this.ads.GetInitialAds();

            if (!this.db.Ads.Any())
            {
                await this.db.Ads.AddRangeAsync(initialAds);
            }

            await this.db.SaveChangesAsync();
        }
    }
}


