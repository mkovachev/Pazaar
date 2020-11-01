using Pazaar.Domain.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Pazaar.Application.Interfaces
{
    public interface IRepository<in TEntity>
        where TEntity : IAggregateRoot
    {
        Task Save(TEntity entity, CancellationToken cancellationToken = default);
    }
}
