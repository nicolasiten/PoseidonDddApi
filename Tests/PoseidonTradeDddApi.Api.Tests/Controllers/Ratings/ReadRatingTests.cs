using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace PoseidonTradeDddApi.Api.Tests.Controllers.Ratings
{
    public class ReadRatingTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public ReadRatingTests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GivenValidRatingId_ReturnsSuccessStatusCode()
        {
            var validId = 1;

            var client = await _factory.GetAuthenticatedClientAsync();

            var response = await client.GetAsync($"/api/rating/{validId}");

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GetAllRatings_ReturnsSuccessStatusCode()
        {
            var client = await _factory.GetAuthenticatedClientAsync();

            var response = await client.GetAsync("/api/rating/getall");

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GivenInvalidRatingId_ReturnsNotFound()
        {
            var invalidId = 33;

            var client = await _factory.GetAuthenticatedClientAsync();

            var response = await client.GetAsync($"/api/rating/{invalidId}");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
