using PoseidonTradeDddApi.Application.Rules.Queries.GetRule;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PoseidonTradeDddApi.Application.Tests.Rules.Queries.GetRule
{
    public class GetRuleItemQueryTests : ApplicationTestBase
    {
        [Fact]
        public async Task Handle_ReturnsCorrectRuleModel()
        {
            var query = new GetRuleQuery
            {
                Id = 1
            };

            var handler = new GetRuleQuery.GetRuleQueryHandler(dbContext, mapper);

            var result = await handler.Handle(query, CancellationToken.None);

            Assert.NotNull(result);
            Assert.Equal("Description", result.Description);
            Assert.Equal("Json", result.Json);
            Assert.Equal("Name", result.Name);
            Assert.Equal("Sql", result.SqlPart);
            Assert.Equal("Sqlstr", result.SqlStr);
            Assert.Equal("Template", result.Template);
        }
    }
}
