using Microsoft.AspNetCore.Mvc;
using Pazaar.Domain.Model.Users;
using Pazaar.Domain.Models.Ads;
using System.Collections.Generic;
using System.Linq;

namespace Pazaar.Web.Features
{
    public class AdsController : ApiController
    {
        private static readonly User TestUser = new User("User", "user@mail.com");

        [HttpGet]
        public IEnumerable<Ad> Get()
            => TestUser.Ads.Where(a => a.IsActive);
    }
}
