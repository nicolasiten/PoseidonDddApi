using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PoseidonTradeDddApi.Application.Common.Interfaces;
using PoseidonTradeDddApi.Application.Ratings.Queries.GetRating;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PoseidonTradeDddApi.Application.Ratings.Queries.GetAllRatings
{
    public class GetAllRatingsQuery : IRequest<IEnumerable<RatingModel>>
    {
        public class GetAllRatingsQueryHandler : IRequestHandler<GetAllRatingsQuery, IEnumerable<RatingModel>>
        {
            private readonly IApplicationDbContext _dbContext;
            private readonly IMapper _mapper;

            public GetAllRatingsQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<IEnumerable<RatingModel>> Handle(GetAllRatingsQuery request, CancellationToken cancellationToken)
            {
                var ratingEntities = await _dbContext.Rating.ToListAsync();

                return _mapper.Map<IEnumerable<RatingModel>>(ratingEntities);
            }
        }
    }
}
