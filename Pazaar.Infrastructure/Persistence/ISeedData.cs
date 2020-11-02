namespace Pazaar.Infrastructure.Persistence
{
    public interface ISeedData
    {
        void SeedDefaultUser();
        void SeedInitialAds();
        void SeedInitialCategories();
    }
}
