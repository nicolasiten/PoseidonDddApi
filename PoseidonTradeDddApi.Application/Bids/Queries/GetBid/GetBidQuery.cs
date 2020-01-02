using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using PoseidonTradeDddApi.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PoseidonTradeDddApi.Application.Bids.Queries.GetBid
{
    public class GetBidQuery : IRequest<BidModel>
    {
        public int BidListId { get; set; }

        public class GetBidQueryHandler : IRequestHandler<GetBidQuery, BidModel>
        {
            private readonly IApplicationDbContext _dbContext;
            private readonly IMapper _mapper;

            public GetBidQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<BidModel> Handle(GetBidQuery request, CancellationToken cancellationToken)
            {
                var bidEntity = await _dbContext.BidList
                    .FindAsync(request.BidListId);

                return _mapper.Map<BidModel>(bidEntity);                
            }
        }
    }
}
