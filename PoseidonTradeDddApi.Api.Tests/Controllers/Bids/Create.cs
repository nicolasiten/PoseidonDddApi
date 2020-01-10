using PoseidonTradeDddApi.Application.Bids.Commands.CreateBidItem;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PoseidonTradeDddApi.Api.Tests.Controllers.Bids
{
    public class Create : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public Create(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GivenValidCreateBidItem_ReturnsSuccessCode()
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
    }
}
