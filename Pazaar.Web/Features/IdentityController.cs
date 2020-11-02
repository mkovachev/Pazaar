using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pazaar.Application.Common;
using Pazaar.Application.Features.Identity.Commands.ChangePassword;
using Pazaar.Application.Features.Identity.Commands.Login;
using Pazaar.Application.Features.Identity.Commands.Register;
using System.Threading.Tasks;

namespace Pazaar.Web.Features
{
    public class IdentityController : ApiController
    {
        [HttpPost]
        [Route(nameof(Register))]
        public async Task<ActionResult<Result>> Register(RegisterCommand command)
      => await Mediator.Send(command);

        [HttpPost]
        [Route(nameof(Login))]
        public async Task<ActionResult<Result>> Login(LoginUserCommand command)
            => await Mediator.Send(command);

        [HttpPut]
        [Authorize]
        [Route(nameof(ChangePassword))]
        public async Task<ActionResult<Result>> ChangePassword(ChangePasswordCommand command)
            => await Mediator.Send(command);
    }
}
