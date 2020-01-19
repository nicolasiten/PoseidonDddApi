using PoseidonTradeDddApi.Application.Trades.Commands.UpdateTradeItem;
using System;
using System.Threading.Tasks;
using Xunit;

namespace PoseidonTradeDddApi.Api.Tests.Controllers.Trades
{
    public class UpdateTradeTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public UpdateTradeTests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GivenValidUpdateTradeItemCommand_ReturnsSuccessStatusCode()
        {
            var client = await _factory.GetAuthenticatedClientAsync();

            var command = new UpdateTradeItemCommand
            {
                TradeId = 1,
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

            var content = IntegrationTestHelper.GetRequestContent(command);

            var response = await client.PutAsync($"/api/trade/{command.TradeId}", content);
        }

        [Fact]
        public async Task GivenInvalidUpdateTradeItemCommand_ReturnsBadRequest()
        {
            var client = await _factory.GetAuthenticatedClientAsync();

            var command = new UpdateTradeItemCommand
            {
                TradeId = 1,
                Account = "This String Will Exceed The Maximum Lenght. This String Will Exceed The Maximum Lenght. This String Will Exceed The Maximum Lenght.",
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
        }
    }
}
