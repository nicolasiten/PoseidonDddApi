using PoseidonTradeDddApi.Application.Common.Exceptions;
using PoseidonTradeDddApi.Application.Ratings.Commands.UpdateRatingItem;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PoseidonTradeDddApi.Application.Tests.Ratings.Commands.UpdateRatingItem
{
    public class UpdateRatingItemCommandTests : ApplicationTestBase
    {
        [Fact]
        public async Task Handle_ValidId_ShouldUpdatePersistedRatingItem()
        {
            var command = new UpdateRatingItemCommand
            {
                Id = 1,
                FitchRating = "Fitchs",
                MoodysRating = "Moodys",
                OrderNumber = 3,
                SandPrating = "Sands"
            };

            var handler = new UpdateRatingItemCommand.UpdateRatingItemCommandHandler(dbContext, mapper);

            await handler.Handle(command, CancellationToken.None);

            var entity = dbContext.Rating.Find(command.Id);

            Assert.NotNull(entity);
            Assert.Equal(command.FitchRating, entity.FitchRating);
            Assert.Equal(command.MoodysRating, entity.MoodysRating);
            Assert.Equal(command.OrderNumber, entity.OrderNumber);
            Assert.Equal(command.SandPrating, entity.SandPrating);
        }

        [Fact]
        public async Task Handle_InvalidId_ThrowsException()
        {
            var command = new UpdateRatingItemCommand
            {
                Id = 43,
                FitchRating = "Fitchs",
                MoodysRating = "Moodys",
                OrderNumber = 3,
                SandPrating = "Sands"
            };

            var handler = new UpdateRatingItemCommand.UpdateRatingItemCommandHandler(dbContext, mapper);

            await Assert.ThrowsAsync<NotFoundException>(() =>
                handler.Handle(command, CancellationToken.None));
        }
    }
}
