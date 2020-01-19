using PoseidonTradeDddApi.Application.Common.Exceptions;
using PoseidonTradeDddApi.Application.Trades.Commands.DeleteTradeItem;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PoseidonTradeDddApi.Application.Tests.Trades.Commands.DeleteTradeItem
{
    public class DeleteTradeItemCommandTests : ApplicationTestBase
    {
        [Fact]
        public async Task Handle_ValidId_ShouldRemovePersistedTradeItem()
        {
            var command = new DeleteTradeItemCommand
            {
                TradeId = 1
            };

            var handler = new DeleteTradeItemCommand.DeleteTradeItemCommandHandler(dbContext);

            await handler.Handle(command, CancellationToken.None);

            var entity = dbContext.Trade.Find(command.TradeId);

            Assert.Null(entity);
        }

        [Fact]
        public async Task Handle_InvalidId_ThrowsException()
        {
            var command = new DeleteTradeItemCommand
            {
                TradeId = 33
            };

            var handler = new DeleteTradeItemCommand.DeleteTradeItemCommandHandler(dbContext);

            await Assert.ThrowsAsync<NotFoundException>(() =>
                handler.Handle(command, CancellationToken.None));
        }
    }
}
