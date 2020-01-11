using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PoseidonTradeDddApi.Api.Tests.Controllers.Bids
{
    public class DeleteBid : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public DeleteBid(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GivenValidBidId_ReturnsSuccessStatusCode()
        {
            var validId = 1;

            var client = await _factory.GetAuthenticatedClientAsync();

            var response = await client.DeleteAsync($"/api/bid/{validId}");

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GivenInvalidBidId_ReturnstNotFound()
        {
            var invalidId = 44;

            var client = await _factory.GetAuthenticatedClientAsync();

            var response = await client.DeleteAsync($"/api/bid/{invalidId}");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
