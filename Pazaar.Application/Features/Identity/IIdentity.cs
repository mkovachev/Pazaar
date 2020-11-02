using Pazaar.Application.Common;
using Pazaar.Application.Features.Identity;
using Pazaar.Application.Features.Identity.Commands;
using Pazaar.Application.Features.Identity.Commands.ChangePassword;
using System.Threading.Tasks;

namespace Pazaar.Application.Identity
{
    public interface IIdentity
    {
        Task<Result<IUser>> Register(UserInputModel userInput);

        Task<Result> Login(UserInputModel userInput);

        Task<Result> ChangePassword(ChangePasswordInputModel changePasswordInput);

        Task<Result> DeleteUserAsync(string userId);
    }
}
