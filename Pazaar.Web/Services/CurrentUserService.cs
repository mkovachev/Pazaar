using Microsoft.AspNetCore.Http;
using Pazaar.Application.Interfaces;
using System;
using System.Security.Claims;

namespace Pazaar.Web.Services
{
    public class CurrentUserService : ICurrentUserId
    {
        //public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        //{
        //    var user = httpContextAccessor.HttpContext?.User;

        //    if (user == null)
        //    {
        //        throw new InvalidOperationException("This request does not have an authenticated user.");
        //    }

        //    this.UserId = user.FindFirst(ClaimTypes.NameIdentifier).Value;
        //}

        //public string UserId { get; }
        public string UserId => throw new NotImplementedException();
    }
}
