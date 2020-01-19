using PoseidonTradeDddApi.Application.Trades.Queries.GetTrade;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PoseidonTradeDddApi.Application.Tests.Trades.Queries.GetTrade
{
    public class GetTradeQueryTests : ApplicationTestBase
    {
        [Fact]
        public async Task Handle_ReturnsCorrectTradeModel()
        {
            var query = new GetTradeQuery
            {
                TradeId = 1
            };

            var handler = new GetTradeQuery.GetTradeQueryHandler(dbContext, mapper);

            var result = await handler.Handle(query, CancellationToken.None);

            Assert.NotNull(result);
            Assert.Equal("Account", result.Account);
            Assert.Equal("Book", result.Book);
            Assert.Equal("DealName", result.DealName);
            Assert.Equal("DealType", result.DealType);
            Assert.Equal("Security", result.Security);
            Assert.Equal("Side", result.Side);
            Assert.Equal("SourceListId", result.SourceListId);
            Assert.Equal("Status", result.Status);
            Assert.Equal("Trader", result.Trader);
            Assert.Equal("Type", result.Type);
            Assert.Equal("Benchmark", result.Benchmark);
            Assert.Equal(1, result.BuyPrice);
            Assert.Equal(2, result.BuyQuantity);
            Assert.Equal(3, result.SellPrice);
            Assert.Equal(4, result.SellQuantity);
            Assert.Equal(new DateTime(2020, 01, 10), result.TradeDate);
        }
    }
}
