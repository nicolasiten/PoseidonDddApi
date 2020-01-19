using PoseidonTradeDddApi.Application.Bids.Queries.GetBid;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PoseidonTradeDddApi.Application.Tests.Bids.Queries.GetBid
{
    public class GetBidQueryTests : ApplicationTestBase
    {
        [Fact]
        public async Task Handle_ReturnsCorrectBidModel()
        {
            var query = new GetBidQuery
            {
                BidListId = 1
            };

            var handler = new GetBidQuery.GetBidQueryHandler(dbContext, mapper);

            var result = await handler.Handle(query, CancellationToken.None);

            Assert.NotNull(result);
            Assert.Equal("Account", result.Account);
            Assert.Equal(1, result.Ask);
            Assert.Equal(2, result.AskQuantity);
            Assert.Equal("Benchmark", result.Benchmark);
            Assert.Equal(3, result.Bid);
            Assert.Equal(new DateTime(2020, 01, 09), result.BidListDate);
            Assert.Equal(4, result.BidQuantity);
            Assert.Equal("Book", result.Book);
            Assert.Equal("Commentary", result.Commentary);
            Assert.Equal("DealName", result.DealName);
            Assert.Equal("DealType", result.DealType);
            Assert.Equal("Security", result.Security);
            Assert.Equal("Side", result.Side);
            Assert.Equal("SourceListId", result.SourceListId);
            Assert.Equal("Status", result.Status);
            Assert.Equal("Trader", result.Trader);
            Assert.Equal("Type", result.Type);
        }
    }
}
