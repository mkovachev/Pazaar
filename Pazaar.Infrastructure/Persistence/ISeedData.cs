using Microsoft.AspNetCore.Identity;
using Pazaar.Infrastructure.Identity;
using System.Threading.Tasks;

namespace Pazaar.Infrastructure.Persistence
{
    public interface ISeedData
    {
        Task SeedDefaultUser(UserManager<User> userManager);
        Task SeedSampleData(PazaarDbContext context);
    }
}
