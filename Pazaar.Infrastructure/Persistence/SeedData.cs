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

        public SeedData(IInitialCategories categories, IInitialAds ads)
        {
            this.categories = categories;
            this.ads = ads;
        }

        public async Task SeedDefaultUser(UserManager<User> userManager)
        {
            var admin = new User("admin@mail.com");

            if (userManager.Users.All(u => u.UserName != admin.Email))
            {
                await userManager.CreateAsync(admin, "admin1234");
            }
        }

        public async Task SeedSampleData(PazaarDbContext context)
        {
            var initialCategories = this.categories.GetInitialCategories();

            if (!context.Categories.Any())
            {
                await context.Categories.AddRangeAsync(initialCategories);
            }

            var initialAds = this.ads.GetInitialAds();

            if (!context.Ads.Any())
            {
                await context.Ads.AddRangeAsync(initialAds);
            }

            await context.SaveChangesAsync();
        }
    }
}


