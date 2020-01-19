using PoseidonTradeDddApi.Application.Bids.Queries.GetAllBids;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PoseidonTradeDddApi.Application.Tests.Bids.Queries.GetAllBids
{
    public class GetAllBidsQueryTests : ApplicationTestBase
    {
        [Fact]
        public async Task Handle_ReturnsCorrectNumberOfBidModels()
        {
            var query = new GetAllBidsQuery();

            var handler = new GetAllBidsQuery.GetAllBidsQueryHandler(dbContext, mapper);

            var result = await handler.Handle(query, CancellationToken.None);

            Assert.NotNull(result);
            Assert.Single(result);
        }
    }
}
