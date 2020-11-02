using Microsoft.AspNetCore.Http;
using Pazaar.Application.Interfaces;
using System.Collections.Generic;
using System.Security.Claims;

namespace Pazaar.Web.Services
{
    public class CurrentUserService : ICurrentUser
    {
        private readonly IHttpContextAccessor accessor;
        public CurrentUserService(IHttpContextAccessor accessor)
        {
            this.accessor = accessor;
        }

        public string UserId => this.accessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

        public string Name => this.accessor.HttpContext.User.Identity.Name;

        public bool IsAuthenticated() => this.accessor.HttpContext.User.Identity.IsAuthenticated;

        public IEnumerable<Claim> GetClaimsIdentity() => this.accessor.HttpContext.User.Claims;
    }
}