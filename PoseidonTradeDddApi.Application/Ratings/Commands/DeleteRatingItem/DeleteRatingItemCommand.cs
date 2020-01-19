using MediatR;
using PoseidonTradeDddApi.Application.Common.Exceptions;
using PoseidonTradeDddApi.Application.Common.Interfaces;
using PoseidonTradeDddApi.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace PoseidonTradeDddApi.Application.Ratings.Commands.DeleteRatingItem
{
    public class DeleteRatingItemCommand : IRequest
    {
        public int Id { get; set; }

        public class DeleteRatingItemCommandHandler : IRequestHandler<DeleteRatingItemCommand>
        {
            private readonly IApplicationDbContext _dbContext;

            public DeleteRatingItemCommandHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<Unit> Handle(DeleteRatingItemCommand request, CancellationToken cancellationToken)
            {
                var ratingEntity = await _dbContext.Rating
                    .FindAsync(request.Id);

                if (ratingEntity == null)
                {
                    throw new NotFoundException(nameof(Rating), request.Id);
                }

                _dbContext.Rating.Remove(ratingEntity);

                await _dbContext.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
