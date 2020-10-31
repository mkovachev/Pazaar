using Microsoft.AspNetCore.Identity;
using Pazaar.Application.Features.Identity.Commands;
using Pazaar.Application.Features.Identity.Commands.ChangePassword;
using Pazaar.Application.Identity;
using Pazaar.Application.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Pazaar.Infrastructure.Identity
{

    public class IdentityService : IIdentity
    {
        private const string InvalidErrorMessage = "Invalid credentials.";

        private readonly UserManager<User> userManager;

        public IdentityService(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<Result> Register(UserInputModel userInput)
        {
            var user = new User(userInput.Email);

            var identityResult = await this.userManager.CreateAsync(user, userInput.Password);

            var errors = identityResult.Errors.Select(e => e.Description);

            return identityResult.Succeeded
                ? Result.Success
                : Result.Failure(errors);
        }
        public async Task<Result> Login(UserInputModel userInput)
        {
            var user = await this.userManager.FindByEmailAsync(userInput.Email);
            if (user == null)
            {
                return InvalidErrorMessage;
            }

            var passwordValid = await this.userManager.CheckPasswordAsync(user, userInput.Password);
            if (!passwordValid)
            {
                return InvalidErrorMessage;
            }

            return null;

            //var token = this.jwtTokenGenerator.GenerateToken(user);

            // return new LoginSuccessModel(user.Id, token);
        }

        public Task<Result> ChangePassword(ChangePasswordInputModel changePasswordInput)
        {
            throw new System.NotImplementedException();
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
