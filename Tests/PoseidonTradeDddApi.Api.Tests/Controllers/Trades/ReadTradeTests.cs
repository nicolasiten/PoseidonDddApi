using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace PoseidonTradeDddApi.Api.Tests.Controllers.Trades
{
    public class ReadTradeTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public ReadTradeTests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GivenValidTradeId_ReturnsSuccessStatusCode()
        {
            var validId = 1;

            var client = await _factory.GetAuthenticatedClientAsync();

            var response = await client.GetAsync($"/api/trade/{validId}");

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GetAllTrades_ReturnsSuccessStatusCode()
        {
            var client = await _factory.GetAuthenticatedClientAsync();

            var response = await client.GetAsync("/api/trade/getall");

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GivenInvalidTradeId_ReturnsNotFound()
        {
            var invalidId = 22;

            var client = await _factory.GetAuthenticatedClientAsync();

            var response = await client.GetAsync($"/api/trade/{invalidId}");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
