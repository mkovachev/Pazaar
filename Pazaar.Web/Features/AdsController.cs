using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pazaar.Application.Common;
using Pazaar.Application.Features.Ads.Commands.Create;
using Pazaar.Application.Features.Ads.Commands.Delete;
using Pazaar.Application.Features.Ads.Commands.Edit;
using System.Threading.Tasks;

namespace Pazaar.Web.Features
{
    public class AdsController : ApiController
    {
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Result>> Create(CreateAdCommand command)
           => await Mediator.Send(command);

        [HttpPut]
        [Authorize]
        [Route(Id)]
        public async Task<ActionResult<Result>> Edit(EditAdCommand command)
         => await Mediator.Send(command);

        [HttpDelete]
        [Authorize]
        [Route(Id)]
        public async Task<ActionResult<Result>> Delete(
            [FromRoute] DeleteAdCommand command)
            => await Mediator.Send(command);

    }
}
