using PoseidonTradeDddApi.Application.Bids.Commands.UpdateBidItem;
using PoseidonTradeDddApi.Application.Common.Exceptions;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PoseidonTradeDddApi.Application.Tests.Bids.Commands.UpdateBidItem
{
    public class UpdateBidItemCommandTests : ApplicationTestBase
    {
        [Fact]
        public async Task Hande_ValidId_ShouldUpdatePersistedBidItem()
        {
            var command = new UpdateBidItemCommand
            {
                BidListId = 1,
                Account = "Accounts",
                Ask = 2,
                AskQuantity = 3,
                Benchmark = "Benchmarks",
                Bid = 4,
                BidListDate = new DateTime(2020, 01, 10),
                BidQuantity = 5,
                Book = "Books",
                Commentary = "Commentarys",
                DealName = "DealNames",
                DealType = "DealTypes",
                Security = "Securitys",
                Side = "Sides",
                SourceListId = "SourceListIds",
                Status = "Statuss",
                Trader = "Traders",
                Type = "Types"
            };

            var handler = new UpdateBidItemCommand.UpdateBidItemCommandHandler(dbContext, mapper);

            await handler.Handle(command, CancellationToken.None);

            var entity = dbContext.BidList.Find(command.BidListId);

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

        [Fact]
        public async Task Handle_InvalidId_ThrowsException()
        {
            var command = new UpdateBidItemCommand
            {
                BidListId = 34,
                Account = "Accounts",
                Ask = 2,
                AskQuantity = 3,
                Benchmark = "Benchmarks",
                Bid = 4,
                BidListDate = new DateTime(2020, 01, 10),
                BidQuantity = 5,
                Book = "Books",
                Commentary = "Commentarys",
                DealName = "DealNames",
                DealType = "DealTypes",
                Security = "Securitys",
                Side = "Sides",
                SourceListId = "SourceListIds",
                Status = "Statuss",
                Trader = "Traders",
                Type = "Types"
            };

            var handler = new UpdateBidItemCommand.UpdateBidItemCommandHandler(dbContext, mapper);

            await Assert.ThrowsAsync<NotFoundException>(() =>
                handler.Handle(command, CancellationToken.None));
        }
    }
}
