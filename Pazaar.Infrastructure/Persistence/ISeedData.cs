using System.Threading.Tasks;

namespace Pazaar.Infrastructure.Persistence
{
    public interface ISeedData
    {
        Task SeedDefaultUser();
        Task SeedSampleData();
    }
}
