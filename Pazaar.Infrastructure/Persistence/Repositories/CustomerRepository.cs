using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Pazaar.Application.Features.Customers;
using Pazaar.Application.Features.Customers.Queries;
using Pazaar.Application.Interfaces;
using Pazaar.Domain.Model.Customer;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Pazaar.Infrastructure.Persistence.Repositories
{
    internal class CustomerRepository : ICustomerRepository, IRepository<Customer>
    {
        private readonly IMapper mapper;
        private readonly PazaarDbContext db;

        public CustomerRepository(IMapper mapper, PazaarDbContext db)
        {
            this.mapper = mapper;
            this.db = db;
        }

        public async Task<Customer> Find(string userId, CancellationToken cancellationToken = default)
        {
            var user = await this.db.Users.FirstOrDefaultAsync(u => u.Id == userId, cancellationToken);

            return await this.db.Customers.FirstOrDefaultAsync(c => c.Id == user.Customer.Id, cancellationToken);

        }

        public async Task<CustomerDetailsOutputModel> GetDetails(int id, CancellationToken cancellationToken = default)
             => await this.db.Customers
                            .Where(c => c.Id == id)
                            .ProjectTo<CustomerDetailsOutputModel>(this.mapper.ConfigurationProvider)
                            .FirstOrDefaultAsync(cancellationToken);

        public async Task<bool> HasAd(int id, int adId, CancellationToken cancellationToken = default)
             => await this.db.Customers
                          .Where(c => c.Id == id)
                          .AnyAsync(c => c.Ads.Any(ad => ad.Id == adId), cancellationToken);

        public async Task Save(Customer entity, CancellationToken cancellationToken = default)
        {
            this.db.Update(entity);

            await this.db.SaveChangesAsync(cancellationToken);
        }
    }
}
