using System.Collections.Generic;
using System.Security.Claims;

namespace Pazaar.Application.Interfaces
{
    public interface ICurrentUser
    {
        string UserId { get; }

        string Name { get; }

        bool IsAuthenticated();

        IEnumerable<Claim> GetClaimsIdentity();

    }
}
