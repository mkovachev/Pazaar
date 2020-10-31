using Microsoft.AspNetCore.Identity;
using Pazaar.Domain.Models.Ads;
using Pazaar.Infrastructure.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace Pazaar.Infrastructure.Persistence
{
    public static class PazaarDbContextSeed
    {
        public static async Task SeedDefaultUser(UserManager<User> userManager)
        {
            var admin = new User("admin@mail.com");

            if (userManager.Users.All(u => u.UserName != admin.Email))
            {
                await userManager.CreateAsync(admin, "admin1234");
            }
        }

        public static async Task SeedSampleData(PazaarDbContext context)
        {
            if (!context.Categories.Any())
            {
                await context.Categories.AddRangeAsync(
                    new Category("Real Estate"),
                    new Category("Cars"),
                    new Category("Electronics"),
                    new Category("Sport"),
                    new Category("Pets"),
                    new Category("Home"),
                    new Category("Men Clothing"),
                    new Category("Men Shoes"),
                    new Category("Men Accessories"),
                    new Category("Men Bags"),
                    new Category("Women Clothing"),
                    new Category("Women Shoes"),
                    new Category("Women Accessories"),
                    new Category("Women Bags"),
                    new Category("Kids Girls Clothing"),
                    new Category("Kids Girls Shoes"),
                    new Category("Kids Girls Accessories"),
                    new Category("Kids Girls Bags"),
                    new Category("Kids Boys Clothing"),
                    new Category("Kids Boys Shoes"),
                    new Category("Kids Boys Accessories"),
                    new Category("Kids Boys Bags"),
                    new Category("Babies"),
                    new Category("Holiday"),
                    new Category("Services"),
                    new Category("Business"),
                    new Category("Jobs"));
            }

            if (!context.Ads.Any())
            {
                await context.Ads.AddRangeAsync(
                    new Ad("Selling my Audi", new Gallery(), 10000.00M, "the best audi is for sale"),
                    new Ad("Selling my BWM", new Gallery(), 10000.00M, "the best bmw is for sale"),
                    new Ad("Selling my Bentley", new Gallery(), 1000000.00M, "the best bentley is for sale")
                    );
            }

            await context.SaveChangesAsync();
        }
    }
}


