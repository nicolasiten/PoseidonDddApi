using AutoMapper;
using MediatR;
using PoseidonTradeDddApi.Application.Common.Exceptions;
using PoseidonTradeDddApi.Application.Common.Interfaces;
using PoseidonTradeDddApi.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PoseidonTradeDddApi.Application.Trades.Commands.UpdateTradeItem
{
    public class UpdateTradeItemCommand : IRequest
    {
        public int TradeId { get; set; }

        public string Account { get; set; }

        public string Type { get; set; }

        public double? BuyQuantity { get; set; }

        public double? SellQuantity { get; set; }

        public double? BuyPrice { get; set; }

        public double? SellPrice { get; set; }

        public DateTime? TradeDate { get; set; }

        public string Security { get; set; }

        public string Status { get; set; }

        public string Trader { get; set; }

        public string Benchmark { get; set; }

        public string Book { get; set; }

        public string DealName { get; set; }

        public string DealType { get; set; }

        public string SourceListId { get; set; }

        public string Side { get; set; }

        public class UpdateTradeItemCommandHandler : IRequestHandler<UpdateTradeItemCommand>
        {
            private readonly IApplicationDbContext _dbContext;
            private readonly IMapper _mapper;

            public UpdateTradeItemCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(UpdateTradeItemCommand request, CancellationToken cancellationToken)
            {
                var tradeEntity = await _dbContext.Trade
                    .FindAsync(request.TradeId);

                if (tradeEntity == null)
                {
                    throw new NotFoundException(nameof(Trade), request.TradeId);
                }

                _mapper.Map(request, tradeEntity);

                await _dbContext.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
