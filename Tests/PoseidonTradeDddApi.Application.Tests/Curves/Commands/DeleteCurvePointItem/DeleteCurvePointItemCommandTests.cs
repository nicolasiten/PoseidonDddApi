using PoseidonTradeDddApi.Application.Common.Exceptions;
using PoseidonTradeDddApi.Application.Curves.Commands.DeleteCurvePointItem;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PoseidonTradeDddApi.Application.Tests.Curves.Commands.DeleteCurvePointItem
{
    public class DeleteCurvePointItemCommandTests : ApplicationTestBase
    {
        [Fact]
        public async Task Handle_ValidId_ShouldRemovePersistedCurvePointItem()
        {
            var command = new DeleteCurvePointItemCommand
            {
                Id = 1
            };

            var handler = new DeleteCurvePointItemCommand.DeleteCurvePointItemCommandHandler(dbContext);

            await handler.Handle(command, CancellationToken.None);

            var entity = dbContext.CurvePoint.Find(command.Id);

            Assert.Null(entity);
        }

        [Fact]
        public async Task Handle_InvalidId_ThrowsException()
        {
            var command = new DeleteCurvePointItemCommand
            {
                Id = 22
            };

            var handler = new DeleteCurvePointItemCommand.DeleteCurvePointItemCommandHandler(dbContext);

            await Assert.ThrowsAsync<NotFoundException>(() =>
                handler.Handle(command, CancellationToken.None));
        }
    }
}
