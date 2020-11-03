using Pazaar.Domain.Models.Ads;

namespace Pazaar.Domain.Factories.Ads
{
    internal class AdFactory : IAdFactory
    {
        private string title = default!;
        private decimal price = default!;
        private string description = default!;

        public Ad Build() => new Ad(this.title, this.price, this.description);
        public Ad Build(string title, decimal price, string description)
            => (Ad)this.WithTitle(title)
                        .WithPrice(price)
                        .WithDescription(description);

        public IAdFactory WithDescription(string description)
        {
            this.description = description;
            return this;
        }

        public IAdFactory WithPrice(decimal price)
        {
            this.price = price;
            return this;
        }

        public IAdFactory WithTitle(string title)
        {
            this.title = title;
            return this;
        }
    }
}
