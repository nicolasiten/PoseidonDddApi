using AutoMapper;
using MediatR;
using PoseidonTradeDddApi.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace PoseidonTradeDddApi.Application.Trades.Queries.GetTrade
{
    public class GetTradeQuery : IRequest<TradeModel>
    {
        public int TradeId { get; set; }

        public class GetTradeQueryHandler : IRequestHandler<GetTradeQuery, TradeModel>
        {
            private readonly IApplicationDbContext _dbContext;
            private readonly IMapper _mapper;

            public GetTradeQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }
            public async Task<TradeModel> Handle(GetTradeQuery request, CancellationToken cancellationToken)
            {
                var tradeEntity = await _dbContext.Trade
                    .FindAsync(request.TradeId);

                return _mapper.Map<TradeModel>(tradeEntity);
            }
        }
    }
}
