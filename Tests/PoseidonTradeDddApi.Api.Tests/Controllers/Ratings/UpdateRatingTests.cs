using PoseidonTradeDddApi.Application.Ratings.Commands.UpdateRatingItem;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace PoseidonTradeDddApi.Api.Tests.Controllers.Ratings
{
    public class UpdateRatingTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public UpdateRatingTests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GivenValidUpdateRatingItemCommand_ReturnsSuccessStatusCode()
        {
            var client = await _factory.GetAuthenticatedClientAsync();

            var command = new UpdateRatingItemCommand
            {
                Id = 1,
                FitchRating = "Fitch",
                MoodysRating = "Moody",
                SandPrating = "Sand",
                OrderNumber = 1
            };

            var content = IntegrationTestHelper.GetRequestContent(command);

            var response = await client.PutAsync($"/api/rating/{command.Id}", content);

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GivenInvalidUpdateRatingItemCommand_ReturnsBadRequest()
        {
            var client = await _factory.GetAuthenticatedClientAsync();

            var command = new UpdateRatingItemCommand
            {
                FitchRating = "This String Will Exceed The Maximum Lenght. This String Will Exceed The Maximum Lenght. This String Will Exceed The Maximum Lenght.",
                MoodysRating = "Moody",
                SandPrating = "Sand",
                OrderNumber = (byte)0
            };

            var content = IntegrationTestHelper.GetRequestContent(command);

            var response = await client.PutAsync($"/api/rating/{command.Id}", content);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
