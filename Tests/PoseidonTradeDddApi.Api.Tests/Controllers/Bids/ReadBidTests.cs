using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace PoseidonTradeDddApi.Api.Tests.Controllers.Bids
{
    public class ReadBidTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public ReadBidTests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GivenValidBidId_ReturnsSuccessStatusCode()
        {
            var validId = 1;

            var client = await _factory.GetAuthenticatedClientAsync();

            var response = await client.GetAsync($"/api/bid/{validId}");

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GetAllBids_ReturnsSuccessStatusCode()
        {
            var client = await _factory.GetAuthenticatedClientAsync();

            var response = await client.GetAsync("/api/bid/getall");

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GivenInvalidBidId_ReturnsNotFound()
        {
            var invalidId = 33;

            var client = await _factory.GetAuthenticatedClientAsync();

            var response = await client.GetAsync($"/api/bid/{invalidId}");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
