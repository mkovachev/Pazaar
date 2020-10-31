using System.Threading.Tasks;

namespace Pazaar.Infrastructure.Persistence
{
    public interface IDbInitializer
    {
        Task Initialize();
    }
}
