using PoseidonTradeDddApi.Application.Ratings.Commands.CreateRatingItem;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace PoseidonTradeDddApi.Api.Tests.Controllers.Ratings
{
    public class CreateRatingTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public CreateRatingTests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GivenValidCreateRatingItem_ReturnsSuccessCode()
        {
            var client = await _factory.GetAuthenticatedClientAsync();

            var command = new CreateRatingItemCommand
            {
                FitchRating = "Fitch",
                MoodysRating = "Moody",
                SandPrating = "Sand",
                OrderNumber = 1
            };

            var content = IntegrationTestHelper.GetRequestContent(command);

            var response = await client.PostAsync("/api/rating", content);

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GivenInvalidCreateRatingItem_ReturnsBadRequest()
        {
            var client = await _factory.GetAuthenticatedClientAsync();

            var command = new CreateRatingItemCommand
            {
                FitchRating = "This String Will Exceed The Maximum Lenght. This String Will Exceed The Maximum Lenght. This String Will Exceed The Maximum Lenght.",
                MoodysRating = "Moody",
                SandPrating = "Sand",
                OrderNumber = (byte)0
            };

            var content = IntegrationTestHelper.GetRequestContent(command);

            var response = await client.PostAsync("api/rating", content);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
