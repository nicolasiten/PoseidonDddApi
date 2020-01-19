using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace PoseidonTradeDddApi.Api.Tests.Controllers.Rules
{
    public class ReadRuleTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public ReadRuleTests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GivenValidRuleId_ReturnsSuccessStatusCode()
        {
            var validId = 1;

            var client = await _factory.GetAuthenticatedClientAsync();

            var response = await client.GetAsync($"/api/rule/{validId}");

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GetAllRules_ReturnsSuccessStatusCode()
        {
            var client = await _factory.GetAuthenticatedClientAsync();

            var response = await client.GetAsync("/api/rule/getall");

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GivenInvalidRuleId_ReturnsNotFound()
        {
            var invalidId = 11;

            var client = await _factory.GetAuthenticatedClientAsync();

            var response = await client.GetAsync($"/api/rule/{invalidId}");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
