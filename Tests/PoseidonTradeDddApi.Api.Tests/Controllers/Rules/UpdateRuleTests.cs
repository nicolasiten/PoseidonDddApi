using PoseidonTradeDddApi.Application.Rules.Commands.UpdateRuleItem;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace PoseidonTradeDddApi.Api.Tests.Controllers.Rules
{
    public class UpdateRuleTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public UpdateRuleTests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GivenValidUpdateRuleItemCommand_ReturnsSuccessStatusCode()
        {
            var client = await _factory.GetAuthenticatedClientAsync();

            var command = new UpdateRuleItemCommand
            {
                Id = 1,
                Description = "Description",
                Json = "Json",
                Name = "Name",
                SqlPart = "Sql",
                SqlStr = "Sqlstr",
                Template = "Template"
            };

            var content = IntegrationTestHelper.GetRequestContent(command);

            var response = await client.PutAsync($"/api/rule/{command.Id}", content);

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GivenInvalidUpdateRuleItemCommand_ReturnsBadRequest()
        {
            var client = await _factory.GetAuthenticatedClientAsync();

            var command = new UpdateRuleItemCommand
            {
                Id = 1,
                Description = "This String Will Exceed The Maximum Lenght. This String Will Exceed The Maximum Lenght. This String Will Exceed The Maximum Lenght.",
                Json = "Json",
                Name = "Name",
                SqlPart = "Sql",
                SqlStr = "Sqlstr",
                Template = "Template"
            };

            var content = IntegrationTestHelper.GetRequestContent(command);

            var response = await client.PutAsync($"/api/rule/{command.Id}", content);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
