using PoseidonTradeDddApi.Application.Curves.Queries.GetCurvePoint;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PoseidonTradeDddApi.Application.Tests.Curves.Queries.GetCurvePoint
{
    public class GetCurvePointQueryTests : ApplicationTestBase
    {
        [Fact]
        public async Task Handle_ReturnsCorrectCurvePointModel()
        {
            var query = new GetCurvePointQuery
            {
                Id = 1
            };

            var handler = new GetCurvePointQuery.GetCurvePointQueryHandler(dbContext, mapper);

            var result = await handler.Handle(query, CancellationToken.None);

            Assert.NotNull(result);
            Assert.Equal(new DateTime(2020, 01, 10), result.AsOfDate);
            Assert.Equal((byte)1, result.CurveId);
            Assert.Equal(1, result.Term);
            Assert.Equal(2, result.Value);
        }
    }
}
