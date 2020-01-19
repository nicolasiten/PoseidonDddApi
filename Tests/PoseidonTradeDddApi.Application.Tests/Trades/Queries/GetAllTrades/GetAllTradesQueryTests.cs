using PoseidonTradeDddApi.Application.Trades.Queries.GetAllTrades;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PoseidonTradeDddApi.Application.Tests.Trades.Queries.GetAllTrades
{
    public class GetAllTradesQueryTests : ApplicationTestBase
    {
        [Fact]
        public async Task Handle_ReturnsCorrectNumberOfTradeModels()
        {
            var query = new GetAllTradesQuery();

            var handler = new GetAllTradesQuery.GetAllTradesQueryHandler(dbContext, mapper);

            var result = await handler.Handle(query, CancellationToken.None);

            Assert.NotNull(result);
            Assert.Single(result);
        }
    }
}
