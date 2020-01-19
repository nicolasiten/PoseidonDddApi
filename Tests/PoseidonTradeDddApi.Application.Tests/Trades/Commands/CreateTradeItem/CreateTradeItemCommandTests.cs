using PoseidonTradeDddApi.Application.Trades.Commands.CreateTradeItem;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PoseidonTradeDddApi.Application.Tests.Trades.Commands.CreateTradeItem
{
    public class CreateTradeItemCommandTests : ApplicationTestBase
    {
        [Fact]
        public async Task Handle_ShouldPersistTradeItem()
        {
            var command = new CreateTradeItemCommand
            {
                Account = "Account",
                Book = "Book",
                DealName = "DealName",
                DealType = "DealType",
                Security = "Security",
                Side = "Side",
                SourceListId = "SourceListId",
                Status = "Status",
                Trader = "Trader",
                Type = "Type",
                Benchmark = "Benchmark",
                BuyPrice = 1,
                BuyQuantity = 2,
                SellPrice = 3,
                SellQuantity = 4,
                TradeDate = new DateTime(2020, 01, 10)
            };

            var handler = new CreateTradeItemCommand.CreateTradeItemCommandHandler(dbContext, mapper);

            await handler.Handle(command, CancellationToken.None);

            var entity = dbContext.Trade.Last();

            Assert.NotNull(entity);
            Assert.Equal(command.Account, entity.Account);
            Assert.Equal(command.Book, entity.Book);
            Assert.Equal(command.DealName, entity.DealName);
            Assert.Equal(command.DealType, entity.DealType);
            Assert.Equal(command.Security, entity.Security);
            Assert.Equal(command.Side, entity.Side);
            Assert.Equal(command.SourceListId, entity.SourceListId);
            Assert.Equal(command.Status, entity.Status);
            Assert.Equal(command.Trader, entity.Trader);
            Assert.Equal(command.Type, entity.Type);
            Assert.Equal(command.Benchmark, entity.Benchmark);
            Assert.Equal(command.BuyPrice, entity.BuyPrice);
            Assert.Equal(command.BuyQuantity, entity.BuyQuantity);
            Assert.Equal(command.SellPrice, entity.SellPrice);
            Assert.Equal(command.SellQuantity, entity.SellQuantity);
            Assert.Equal(command.TradeDate, entity.TradeDate);
        }
    }
}
