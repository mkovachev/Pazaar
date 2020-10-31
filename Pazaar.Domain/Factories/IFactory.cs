using Pazaar.Domain.Common;

namespace Pazaar.Domain.Factories
{
    public interface IFactory<out TEntity>
        where TEntity : IAggregateRoot
    {
        TEntity Build();
    }
}
