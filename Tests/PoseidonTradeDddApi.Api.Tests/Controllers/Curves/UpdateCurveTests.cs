using PoseidonTradeDddApi.Application.Curves.Commands.UpdateCurvePointItem;
using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace PoseidonTradeDddApi.Api.Tests.Controllers.Curves
{
    public class UpdateCurveTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public UpdateCurveTests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GivenValidUpdateCurveItemCommand_ReturnsSuccessCode()
        {
            var client = await _factory.GetAuthenticatedClientAsync();

            var command = new UpdateCurvePointItemCommand
            {
                Id = 1,
                AsOfDate = new DateTime(2020, 01, 10),
                CurveId = 1,
                Term = 1,
                Value = 2
            };

            var content = IntegrationTestHelper.GetRequestContent(command);

            var response = await client.PutAsync($"/api/curvepoint/{command.Id}", content);

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GivenInvalidUpdateCurveItemCommand_ReturnsBadRequest()
        {
            var client = await _factory.GetAuthenticatedClientAsync();

            var command = new UpdateCurvePointItemCommand
            {
                Id = 1,
                AsOfDate = new DateTime(2020, 01, 10),
                CurveId = 1,
                Term = 1,
                Value = -2
            };

            var content = IntegrationTestHelper.GetRequestContent(command);

            var response = await client.PutAsync($"/api/curvepoint/{command.Id}", content);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
