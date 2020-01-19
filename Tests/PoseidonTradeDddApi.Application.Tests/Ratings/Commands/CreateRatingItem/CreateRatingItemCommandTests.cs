using PoseidonTradeDddApi.Application.Ratings.Commands.CreateRatingItem;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PoseidonTradeDddApi.Application.Tests.Ratings.Commands.CreateRatingItem
{
    public class CreateRatingItemCommandTests : ApplicationTestBase
    {
        [Fact]
        public async Task Handle_ShouldPersistRatingItem()
        {
            var command = new CreateRatingItemCommand
            {
                FitchRating = "Fitch",
                MoodysRating = "Moody",
                SandPrating = "Sand",
                OrderNumber = 1
            };

            var handler = new CreateRatingItemCommand.CreateRatingItemCommandHandler(dbContext, mapper);

            await handler.Handle(command, CancellationToken.None);

            var entity = dbContext.Rating.Last();

            Assert.NotNull(entity);
            Assert.Equal(command.FitchRating, entity.FitchRating);
            Assert.Equal(command.MoodysRating, entity.MoodysRating);
            Assert.Equal(command.SandPrating, entity.SandPrating);
            Assert.Equal(command.OrderNumber, entity.OrderNumber);
        }
    }
}
