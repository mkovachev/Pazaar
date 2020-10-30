using Pazaar.Application.Models;
using System.Threading.Tasks;

namespace Pazaar.Application.Interfaces
{
    public interface IIdentityService
    {
        Task<Result> Register(string userName, string password);

        Task<Result> DeleteUserAsync(string userId);
    }
}
