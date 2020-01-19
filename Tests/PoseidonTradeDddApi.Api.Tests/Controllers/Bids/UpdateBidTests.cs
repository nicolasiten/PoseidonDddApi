using PoseidonTradeDddApi.Application.Bids.Commands.UpdateBidItem;
using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace PoseidonTradeDddApi.Api.Tests.Controllers.Bids
{
    public class UpdateBidTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public UpdateBidTests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GivenValidUpdateBidItemCommand_ReturnsSuccessStatusCode()
        {
            var client = await _factory.GetAuthenticatedClientAsync();

            var command = new UpdateBidItemCommand
            {
                BidListId = 1,
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

            var response = await client.PutAsync($"/api/bid/{command.BidListId}", content);

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GivenInvalidUpdateBidItemCommand_ReturnsBadRequest()
        {
            var client = await _factory.GetAuthenticatedClientAsync();

            var command = new UpdateBidItemCommand
            {
                BidListId = 1,
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

            var response = await client.PutAsync($"/api/bid/{command.BidListId}", content);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
