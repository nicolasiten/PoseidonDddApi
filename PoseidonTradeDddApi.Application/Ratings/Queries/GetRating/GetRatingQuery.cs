using AutoMapper;
using MediatR;
using PoseidonTradeDddApi.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace PoseidonTradeDddApi.Application.Ratings.Queries.GetRating
{
    public class GetRatingQuery : IRequest<RatingModel>
    {
        public int Id { get; set; }

        public class GetRatingQueryHandler : IRequestHandler<GetRatingQuery, RatingModel>
        {
            private readonly IApplicationDbContext _dbContext;
            private readonly IMapper _mapper;

            public GetRatingQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<RatingModel> Handle(GetRatingQuery request, CancellationToken cancellationToken)
            {
                var ratingEntity = await _dbContext.Rating
                    .FindAsync(request.Id);

                return _mapper.Map<RatingModel>(ratingEntity);
            }
        }
    }
}
