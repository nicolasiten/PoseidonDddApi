using PoseidonTradeDddApi.Application.Rules.Commands.CreateRuleItem;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace PoseidonTradeDddApi.Api.Tests.Controllers.Rules
{
    public class CreateRuleTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public CreateRuleTests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GivenValidCreateRuleItem_ReturnsSuccessStatusCode()
        {
            var client = await _factory.GetAuthenticatedClientAsync();

            var command = new CreateRuleItemCommand
            {
                Description = "Description",
                Json = "Json",
                Name = "Name",
                SqlPart = "Sql",
                SqlStr = "Sqlstr",
                Template = "Template"
            };

            var content = IntegrationTestHelper.GetRequestContent(command);

            var response = await client.PostAsync("api/rule", content);

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GivenInvalidCreateRuleItem_ReturnsBadRequest()
        {
            var client = await _factory.GetAuthenticatedClientAsync();

            var command = new CreateRuleItemCommand
            {
                Description = "This String Will Exceed The Maximum Lenght. This String Will Exceed The Maximum Lenght. This String Will Exceed The Maximum Lenght.",
                Json = "Json",
                Name = "Name",
                SqlPart = "Sql",
                SqlStr = "Sqlstr",
                Template = "Template"
            };

            var content = IntegrationTestHelper.GetRequestContent(command);

            var response = await client.PostAsync("/api/rule", content);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
