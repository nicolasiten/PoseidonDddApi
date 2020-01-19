using PoseidonTradeDddApi.Application.Bids.Commands.DeleteBidItem;
using PoseidonTradeDddApi.Application.Common.Exceptions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PoseidonTradeDddApi.Application.Tests.Bids.Commands.DeleteBidItem
{
    public class DeleteBidItemCommandTests : ApplicationTestBase
    {
        [Fact]
        public async Task Handle_ValidId_ShouldRemovePersistedBidItem()
        {
            var command = new DeleteBidItemCommand
            {
                BidListId = 1
            };

            var handler = new DeleteBidItemCommand.DeleteBidItemCommandHandler(dbContext);

            await handler.Handle(command, CancellationToken.None);

            var entity = dbContext.BidList.Find(command.BidListId);

            Assert.Null(entity);
        }

        [Fact]
        public async Task Handle_InvalidId_ThrowsException()
        {
            var command = new DeleteBidItemCommand
            {
                BidListId = 22
            };

            var handler = new DeleteBidItemCommand.DeleteBidItemCommandHandler(dbContext);

            await Assert.ThrowsAsync<NotFoundException>(() =>
                handler.Handle(command, CancellationToken.None));
        }
    }
}
