using PoseidonTradeDddApi.Application.Common.Exceptions;
using PoseidonTradeDddApi.Application.Ratings.Commands.DeleteRatingItem;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PoseidonTradeDddApi.Application.Tests.Ratings.Commands.DeleteRatingItem
{
    public class DeleteRatingItemCommandTests : ApplicationTestBase
    {
        [Fact]
        public async Task Handle_ValidId_ShouldRemovePersistedRatingItem()
        {
            var command = new DeleteRatingItemCommand
            {
                Id = 1
            };

            var handler = new DeleteRatingItemCommand.DeleteRatingItemCommandHandler(dbContext);

            await handler.Handle(command, CancellationToken.None);

            var entity = dbContext.Rating.Find(command.Id);

            Assert.Null(entity);
        }

        [Fact]
        public async Task Handle_InvalidId_ThrowsException()
        {
            var command = new DeleteRatingItemCommand
            {
                Id = 33
            };

            var handler = new DeleteRatingItemCommand.DeleteRatingItemCommandHandler(dbContext);

            await Assert.ThrowsAsync<NotFoundException>(() =>
                handler.Handle(command, CancellationToken.None));
        }
    }
}
