using Microsoft.AspNetCore.Mvc;

namespace Pazaar.Web
{
    [ApiController]
    [Route("[controller]")]
    public abstract class ApiController : ControllerBase
    {
    }
}
