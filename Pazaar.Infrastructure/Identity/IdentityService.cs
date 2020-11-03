using Microsoft.AspNetCore.Identity;
using Pazaar.Application.Common;
using Pazaar.Application.Features.Identity;
using Pazaar.Application.Features.Identity.Commands;
using Pazaar.Application.Features.Identity.Commands.ChangePassword;
using Pazaar.Application.Identity;
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

        public async Task<Result<IUser>> Register(UserInputModel userInput)
        {
            var user = new User(userInput.Email);

            var identityResult = await this.userManager.CreateAsync(user, userInput.Password);

            var errors = identityResult.Errors.Select(e => e.Description);

            return identityResult.Succeeded
                ? Result<IUser>.SuccessWith(user)
                : Result<IUser>.Failure(errors);
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

            //var token = this.jwtTokenGenerator.GenerateToken(user);

            return Result.Success; // Todo new LoginSuccessModel(token);
        }

        public async Task<Result> ChangePassword(ChangePasswordInputModel changePasswordInput)
        {
            var user = await this.userManager.FindByIdAsync(changePasswordInput.UserId);

            if (user == null)
            {
                return InvalidErrorMessage;
            }

            var identityResult = await this.userManager.ChangePasswordAsync(
                user,
                changePasswordInput.CurrentPassword,
                changePasswordInput.NewPassword);

            var errors = identityResult.Errors.Select(e => e.Description);

            return identityResult.Succeeded
                ? Result.Success
                : Result.Failure(errors);
        }

        public async Task<Result> DeleteUserAsync(string userId)
        {
            var user = userManager.Users.SingleOrDefault(u => u.Id == userId);

            if (user != null)
            {
                await this.userManager.DeleteAsync(user);
            }

            return Result.Success; // Todo
        }
    }
}
