using MediatR;
using Pazaar.Application.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Pazaar.Application.Features.Ads.Commands.Edit
{
    public class EditAdCommand : AddCommand<EditAdCommand>, IRequest<Result>
    {
        public class EditAdCommandHandler : IRequestHandler<EditAdCommand, Result>
        {
            private readonly IAdRepository adRepository;

            public EditAdCommandHandler(IAdRepository adRepository)
            {
                this.adRepository = adRepository;
            }
            public async Task<Result> Handle(EditAdCommand request, CancellationToken cancellationToken)
            {
                var ad = await this.adRepository.Find(request.Id, cancellationToken);

                ad.UpdateTitle(request.Title)
                  .UpdatePrice(request.Price)
                  .UpdateDescription(request.Description);

                await this.adRepository.Save(ad, cancellationToken);

                return Result.Success;
            }
        }
    }
}
