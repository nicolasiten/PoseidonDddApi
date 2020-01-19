using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PoseidonTradeDddApi.Application.Bids.Queries.GetBid;
using PoseidonTradeDddApi.Application.Common.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PoseidonTradeDddApi.Application.Bids.Queries.GetAllBids
{
    public class GetAllBidsQuery : IRequest<IEnumerable<BidModel>>
    {
        public class GetAllBidsQueryHandler : IRequestHandler<GetAllBidsQuery, IEnumerable<BidModel>>
        {
            private readonly IApplicationDbContext _dbContext;
            private readonly IMapper _mapper;

            public GetAllBidsQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<IEnumerable<BidModel>> Handle(GetAllBidsQuery request, CancellationToken cancellationToken)
            {
                var bidEntities = await _dbContext.BidList.ToListAsync();

                return _mapper.Map<IEnumerable<BidModel>>(bidEntities);
            }
        }
    }
}
