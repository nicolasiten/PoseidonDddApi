using PoseidonTradeDddApi.Application.Curves.Commands.CreateCurvePointItem;
using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace PoseidonTradeDddApi.Api.Tests.Controllers.Curves
{
    public class CreateCurveTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public CreateCurveTests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GivenValidCreateCurveItem_ReturnsSuccessStatusCode()
        {
            var client = await _factory.GetAuthenticatedClientAsync();

            var command = new CreateCurvePointItemCommand
            {
                AsOfDate = new DateTime(2020, 01, 10),
                CurveId = 1,
                Term = 1,
                Value = 2
            };

            var content = IntegrationTestHelper.GetRequestContent(command);

            var response = await client.PostAsync("api/curvepoint", content);

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GivenInvalidCurveItem_ReturnsBadRequest()
        {
            var client = await _factory.GetAuthenticatedClientAsync();

            var command = new CreateCurvePointItemCommand
            {
                AsOfDate = new DateTime(2020, 01, 10),
                CurveId = (byte)2,
                Term = 1,
                Value = -2
            };

            var content = IntegrationTestHelper.GetRequestContent(command);

            var response = await client.PostAsync("/api/curvepoint", content);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
