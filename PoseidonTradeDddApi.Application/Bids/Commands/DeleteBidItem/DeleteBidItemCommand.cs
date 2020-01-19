using MediatR;
using PoseidonTradeDddApi.Application.Common.Exceptions;
using PoseidonTradeDddApi.Application.Common.Interfaces;
using PoseidonTradeDddApi.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace PoseidonTradeDddApi.Application.Bids.Commands.DeleteBidItem
{
    public class DeleteBidItemCommand : IRequest
    {
        public int BidListId { get; set; }

        public class DeleteBidItemCommandHandler : IRequestHandler<DeleteBidItemCommand>
        {
            private readonly IApplicationDbContext _dbContext;

            public DeleteBidItemCommandHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<Unit> Handle(DeleteBidItemCommand request, CancellationToken cancellationToken)
            {
                var bidEntity = await _dbContext.BidList
                    .FindAsync(request.BidListId);

                if (bidEntity == null)
                {
                    throw new NotFoundException(nameof(BidList), request.BidListId);
                }

                _dbContext.BidList.Remove(bidEntity);

                await _dbContext.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
