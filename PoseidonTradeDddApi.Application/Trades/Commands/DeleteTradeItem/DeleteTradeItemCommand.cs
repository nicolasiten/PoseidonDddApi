using MediatR;
using PoseidonTradeDddApi.Application.Common.Exceptions;
using PoseidonTradeDddApi.Application.Common.Interfaces;
using PoseidonTradeDddApi.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace PoseidonTradeDddApi.Application.Trades.Commands.DeleteTradeItem
{
    public class DeleteTradeItemCommand : IRequest
    {
        public int TradeId { get; set; }

        public class DeleteTradeItemCommandHandler : IRequestHandler<DeleteTradeItemCommand>
        {
            private readonly IApplicationDbContext _dbContext;

            public DeleteTradeItemCommandHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<Unit> Handle(DeleteTradeItemCommand request, CancellationToken cancellationToken)
            {
                var tradeEntity = await _dbContext.Trade
                    .FindAsync(request.TradeId);

                if (tradeEntity == null)
                {
                    throw new NotFoundException(nameof(Trade), request.TradeId);
                }

                _dbContext.Trade.Remove(tradeEntity);

                await _dbContext.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
