namespace Pazaar.Application.Features
{
    public class EntityCommand<TId>
    {
        public TId Id { get; set; } = default!;
    }
}
