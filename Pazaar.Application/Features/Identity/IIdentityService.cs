using Pazaar.Application.Common;
using Pazaar.Application.Features.Identity.Commands;
using Pazaar.Application.Features.Identity.Commands.ChangePassword;
using Pazaar.Application.Features.Identity.Commands.Login;
using System.Threading.Tasks;

namespace Pazaar.Application.Features.Identity
{
    public interface IIdentityService
    {
        Task<Result<IUser>> Register(UserInputModel userInput);

        Task<Result<LoginSuccessModel>> Login(UserInputModel userInput);

        Task<Result> ChangePassword(ChangePasswordInputModel changePasswordInput);
    }
}
