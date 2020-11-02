using MediatR;
using Pazaar.Application.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Pazaar.Application.Features.Ads.Commands.Delete
{
    public class DeleteAdCommand : AdCommand<DeleteAdCommand>, IRequest<Result>
    {
        public class DeleteAdCommandHandler : IRequestHandler<DeleteAdCommand, Result>
        {
            private readonly IAdRepository adRepository;

            public DeleteAdCommandHandler(IAdRepository adRepository)
            {
                this.adRepository = adRepository;
            }
            public async Task<Result> Handle(DeleteAdCommand request, CancellationToken cancellationToken)
            {
                var ad = await adRepository.Find(request.Id, cancellationToken);

                if (ad == null)
                {
                    return false;
                }

                await adRepository.Delete(ad.Id, cancellationToken);
                return Result.Success;
            }
        }
    }
}
