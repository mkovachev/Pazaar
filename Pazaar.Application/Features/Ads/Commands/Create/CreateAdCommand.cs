using MediatR;
using Pazaar.Application.Common;
using Pazaar.Application.Features.Customers;
using Pazaar.Application.Interfaces;
using Pazaar.Domain.Factories.Ads;
using System.Threading;
using System.Threading.Tasks;

namespace Pazaar.Application.Features.Ads.Commands.Create
{
    public class CreateAdCommand : AddCommand<CreateAdCommand>, IRequest<Result>
    {
        public class CreateAdCommandHander : IRequestHandler<CreateAdCommand, Result>
        {
            private readonly IAdFactory adFactory;
            private readonly IAdRepository adRepository;
            private readonly ICustomerRepository customerRepository;
            private readonly ICurrentUser currentUser;
            public CreateAdCommandHander(IAdFactory adFactory, IAdRepository adRepository, ICustomerRepository customerRepository, ICurrentUser currentUser)
            {
                this.adFactory = adFactory;
                this.adRepository = adRepository;
                this.customerRepository = customerRepository;
                this.currentUser = currentUser;
            }

            public async Task<Result> Handle(CreateAdCommand request, CancellationToken cancellationToken)
            {
                var customer = await this.customerRepository.FindByUser(
                    this.currentUser.UserId,
                    cancellationToken);

                var ad = this.adFactory.Build();

                customer.AddAd(ad);

                await this.adRepository.Save(ad, cancellationToken);

                return Result.Success;
            }
        }
    }
}
