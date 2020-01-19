using PoseidonTradeDddApi.Application.Trades.Commands.CreateTradeItem;
using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace PoseidonTradeDddApi.Api.Tests.Controllers.Trades
{
    public class CreateTradeTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public CreateTradeTests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GivenValidCreateTradeItem_ReturnsSuccessStatusCode()
        {
            var client = await _factory.GetAuthenticatedClientAsync();

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

            var content = IntegrationTestHelper.GetRequestContent(command);

            var response = await client.PostAsync("/api/trade", content);

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GivenInvalidCreateTradeItem_ReturnsBadRequest()
        {
            var client = await _factory.GetAuthenticatedClientAsync();

            var command = new CreateTradeItemCommand
            {
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

            var content = IntegrationTestHelper.GetRequestContent(command);

            var response = await client.PostAsync("api/trade", content);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
