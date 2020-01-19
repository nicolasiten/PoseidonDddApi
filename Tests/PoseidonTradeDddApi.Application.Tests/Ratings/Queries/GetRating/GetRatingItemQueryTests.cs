using PoseidonTradeDddApi.Application.Ratings.Queries.GetRating;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PoseidonTradeDddApi.Application.Tests.Ratings.Queries.GetRating
{
    public class GetRatingItemQueryTests : ApplicationTestBase
    {
        [Fact]
        public async Task Handle_ReturnsCorrectRatingModel()
        {
            var query = new GetRatingQuery
            {
                Id = 1
            };

            var handler = new GetRatingQuery.GetRatingQueryHandler(dbContext, mapper);

            var result = await handler.Handle(query, CancellationToken.None);

            Assert.NotNull(result);
            Assert.Equal("Fitch", result.FitchRating);
            Assert.Equal("Moody", result.MoodysRating);
            Assert.Equal("Sand", result.SandPrating);
            Assert.Equal((byte)1, result.OrderNumber);
        }
    }
}
