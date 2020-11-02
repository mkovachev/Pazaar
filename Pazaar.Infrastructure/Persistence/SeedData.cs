using Microsoft.AspNetCore.Identity;
using Pazaar.Domain.Common;
using Pazaar.Infrastructure.Identity;
using System.Linq;

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

        public void SeedDefaultUser()
        {
            var admin = new User("admin@mail.com");

            if (this.userManager.Users.All(u => u.UserName != admin.Email))
            {
                this.userManager.CreateAsync(admin, "admin1234");
            }

            this.db.SaveChanges();
        }

        public void SeedInitialAds()
        {
            var initialAds = this.ads.GetInitialAds();

            if (!this.db.Ads.Any())
            {
                foreach (var entity in initialAds)
                {
                    this.db.Add(entity);
                }
            }

            this.db.SaveChanges();
        }
        public void SeedInitialCategories()
        {
            var initialCategories = this.categories.GetInitialCategories();

            if (!this.db.Categories.Any())
            {
                foreach (var entity in initialCategories)
                {
                    this.db.Add(entity);
                }

                this.db.SaveChanges();
            }
        }
    }
}


