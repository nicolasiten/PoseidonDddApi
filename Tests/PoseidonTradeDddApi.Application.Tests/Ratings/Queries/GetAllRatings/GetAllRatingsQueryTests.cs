using PoseidonTradeDddApi.Application.Ratings.Queries.GetAllRatings;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PoseidonTradeDddApi.Application.Tests.Ratings.Queries.GetAllRatings
{
    public class GetAllRatingsQueryTests : ApplicationTestBase
    {
        [Fact]
        public async Task Handle_ReturnsCorrectNumberOfRatingModels()
        {
            var query = new GetAllRatingsQuery();

            var handler = new GetAllRatingsQuery.GetAllRatingsQueryHandler(dbContext, mapper);

            var result = await handler.Handle(query, CancellationToken.None);

            Assert.NotNull(result);
            Assert.Single(result);
        }
    }
}
