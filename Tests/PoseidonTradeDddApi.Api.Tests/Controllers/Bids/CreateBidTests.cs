using PoseidonTradeDddApi.Application.Bids.Commands.CreateBidItem;
using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace PoseidonTradeDddApi.Api.Tests.Controllers.Bids
{
    public class CreateBidTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public CreateBidTests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GivenValidCreateBidItem_ReturnsSuccessStatusCode()
        {
            var client = await _factory.GetAuthenticatedClientAsync();

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

            var content = IntegrationTestHelper.GetRequestContent(command);

            var response = await client.PostAsync("/api/bid", content);

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GivenInvalidCreateBidItem_ReturnsBadRequest()
        {
            var client = await _factory.GetAuthenticatedClientAsync();

            var command = new CreateBidItemCommand
            {
                Account = "This String Will Exceed The Maximum Lenght.",
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

            var content = IntegrationTestHelper.GetRequestContent(command);

            var response = await client.PostAsync("/api/bid", content);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
