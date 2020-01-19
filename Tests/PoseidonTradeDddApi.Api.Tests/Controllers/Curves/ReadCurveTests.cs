using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace PoseidonTradeDddApi.Api.Tests.Controllers.Curves
{
    public class ReadCurveTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public ReadCurveTests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GivenValidCurveId_ReturnsSuccessStatusCode()
        {
            var validId = 1;

            var client = await _factory.GetAuthenticatedClientAsync();

            var response = await client.GetAsync($"/api/curvepoint/{validId}");

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GetAllCurves_ReturnsSuccessStatusCode()
        {
            var client = await _factory.GetAuthenticatedClientAsync();

            var response = await client.GetAsync("/api/curvepoint/getall");

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GivenInvalidCurveId_ReturnsNotFound()
        {
            var invalidId = 22;

            var client = await _factory.GetAuthenticatedClientAsync();

            var response = await client.GetAsync($"/api/curvepoint/{invalidId}");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
