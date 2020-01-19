using PoseidonTradeDddApi.Application.Bids.Commands.CreateBidItem;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PoseidonTradeDddApi.Application.Tests.Bids.Commands.CreateBidItem
{
    public class CreateBidItemCommandTests : ApplicationTestBase
    {
        [Fact]
        public async Task Handle_ShouldPersistBidItem()
        {
            var command = new CreateBidItemCommand
            {
                Account = "Account",
                Ask = 1,
                AskQuantity = 2,
                Benchmark = "Benchmark",
                Bid = 3,
                BidListDate = new DateTime(2020, 01, 09),
                BidQuantity = 4,
                Book = "Book",
                Commentary = "Commentary",
                DealName = "DealName",
                DealType = "DealType",
                Security = "Security",
                Side = "Side",
                SourceListId = "SourceListId",
                Status = "Status",
                Trader = "Trader",
                Type = "Type"
            };

            var handler = new CreateBidItemCommand.CreateBidItemCommandHandler(dbContext, mapper);

            await handler.Handle(command, CancellationToken.None);

            var entity = dbContext.BidList.Last();

            Assert.NotNull(entity);
            Assert.Equal(command.Account, entity.Account);
            Assert.Equal(command.Ask, entity.Ask);
            Assert.Equal(command.AskQuantity, entity.AskQuantity);
            Assert.Equal(command.Benchmark, entity.Benchmark);
            Assert.Equal(command.Bid, entity.Bid);
            Assert.Equal(command.BidListDate, entity.BidListDate);
            Assert.Equal(command.BidQuantity, entity.BidQuantity);
            Assert.Equal(command.Book, entity.Book);
            Assert.Equal(command.Commentary, entity.Commentary);
            Assert.Equal(command.DealName, entity.DealName);
            Assert.Equal(command.DealType, entity.DealType);
            Assert.Equal(command.Security, entity.Security);
            Assert.Equal(command.Side, entity.Side);
            Assert.Equal(command.SourceListId, entity.SourceListId);
            Assert.Equal(command.Status, entity.Status);
            Assert.Equal(command.Trader, entity.Trader);
            Assert.Equal(command.Type, entity.Type);
        }
    }
}
