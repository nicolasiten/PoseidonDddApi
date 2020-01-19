using AutoMapper;
using MediatR;
using PoseidonTradeDddApi.Application.Common.Exceptions;
using PoseidonTradeDddApi.Application.Common.Interfaces;
using PoseidonTradeDddApi.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace PoseidonTradeDddApi.Application.Ratings.Commands.UpdateRatingItem
{
    public class UpdateRatingItemCommand : IRequest
    {
        public int Id { get; set; }

        public string MoodysRating { get; set; }

        public string SandPrating { get; set; }

        public string FitchRating { get; set; }

        public byte? OrderNumber { get; set; }

        public class UpdateRatingItemCommandHandler : IRequestHandler<UpdateRatingItemCommand>
        {
            private readonly IApplicationDbContext _dbContext;
            private readonly IMapper _mapper;

            public UpdateRatingItemCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(UpdateRatingItemCommand request, CancellationToken cancellationToken)
            {
                var ratingEntity = await _dbContext.Rating
                    .FindAsync(request.Id);

                if (ratingEntity == null)
                {
                    throw new NotFoundException(nameof(Rating), request.Id);
                }

                _mapper.Map(request, ratingEntity);

                await _dbContext.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
