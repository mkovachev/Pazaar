using Microsoft.AspNetCore.Identity;
using Pazaar.Application.Interfaces;
using Pazaar.Application.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Pazaar.Infrastructure.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<User> userManager;

        public IdentityService(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<Result> Register(string userName, string password)
        {
            var user = new User
            {
                UserName = userName,
                Email = userName,
            };

            var identityResult = await this.userManager.CreateAsync(user, password);

            var errors = identityResult.Errors.Select(e => e.Description).ToList();

            return identityResult.Succeeded
                ? Result.Success
                : Result.Failure(errors);
        }

        public async Task<Result> DeleteUserAsync(string userId)
        {
            var user = userManager.Users.SingleOrDefault(u => u.Id == userId);

            if (user != null)
            {
                await userManager.DeleteAsync(user);
            }

            return Result.Success;
        }
    }
}
