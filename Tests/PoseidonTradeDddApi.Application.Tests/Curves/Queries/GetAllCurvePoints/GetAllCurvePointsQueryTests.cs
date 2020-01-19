using PoseidonTradeDddApi.Application.Curves.Queries.GetAllCurvePoints;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PoseidonTradeDddApi.Application.Tests.Curves.Queries.GetAllCurvePoints
{
    public class GetAllCurvePointsQueryTests : ApplicationTestBase
    {
        [Fact]
        public async Task Handle_ReturnsCorrectNumberOfCurvePointModels()
        {
            var query = new GetAllCurvePointsQuery();

            var handler = new GetAllCurvePointsQuery.GetAllCuvePointsQueryHandler(dbContext, mapper);

            var result = await handler.Handle(query, CancellationToken.None);

            Assert.NotNull(result);
            Assert.Single(result);
        }
    }
}
