using Pazaar.Domain.Models.Ads;

namespace Pazaar.Application.Features
{
    public abstract class AddCommand<TCommand> : EntityCommand<int>
    {
        public string Title { get; private set; } = default!;
        public Gallery Gallery { get; private set; } = default!;
        public decimal Price { get; private set; } = default!;
        public string Description { get; private set; } = default!;
        public bool IsActive { get; private set; } = true;
    }
}
