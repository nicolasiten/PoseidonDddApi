using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PoseidonTradeDddApi.Application.Common.Interfaces;
using PoseidonTradeDddApi.Application.Trades.Queries.GetTrade;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PoseidonTradeDddApi.Application.Trades.Queries.GetAllTrades
{
    public class GetAllTradesQuery : IRequest<IEnumerable<TradeModel>>
    {
        public class GetAllTradesQueryHandler : IRequestHandler<GetAllTradesQuery, IEnumerable<TradeModel>>
        {
            private readonly IApplicationDbContext _dbContext;
            private readonly IMapper _mapper;

            public GetAllTradesQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<IEnumerable<TradeModel>> Handle(GetAllTradesQuery request, CancellationToken cancellationToken)
            {
                var tradeEntities = await _dbContext.Trade.ToListAsync();

                return _mapper.Map<IEnumerable<TradeModel>>(tradeEntities);
            }
        }
    }
}
