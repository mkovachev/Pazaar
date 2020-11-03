using Microsoft.AspNetCore.Mvc;
using Pazaar.Application.Features.Customers.Queries.Details;
using System.Threading.Tasks;

namespace Pazaar.Web.Features
{
    public class CustomersController : ApiController
    {
        [HttpGet]
        [Route(Id)]
        public async Task<ActionResult<CustomerDetailsOutputModel>> Details(
            [FromRoute] CustomerDetailsQuery query)
            => await Mediator.Send(query);
    }
}
