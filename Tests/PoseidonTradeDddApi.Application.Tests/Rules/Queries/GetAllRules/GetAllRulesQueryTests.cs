using PoseidonTradeDddApi.Application.Rules.Queries.GetAllRules;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PoseidonTradeDddApi.Application.Tests.Rules.Queries.GetAllRules
{
    public class GetAllRulesQueryTests : ApplicationTestBase
    {
        [Fact]
        public async Task Handle_ReturnsCorrectNumberOfRuleModels()
        {
            var query = new GetAllRulesQuery();

            var handler = new GetAllRulesQuery.GetAllRulesQueryHandler(dbContext, mapper);

            var result = await handler.Handle(query, CancellationToken.None);

            Assert.NotNull(result);
            Assert.Single(result);
        }
    }
}
