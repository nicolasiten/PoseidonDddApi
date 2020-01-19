using PoseidonTradeDddApi.Application.Common.Exceptions;
using PoseidonTradeDddApi.Application.Curves.Commands.UpdateCurvePointItem;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PoseidonTradeDddApi.Application.Tests.Curves.Commands.UpdateCurvePointItem
{
    public class UpdateCurvePointItemCommandTests : ApplicationTestBase
    {
        [Fact]
        public async Task Handle_ValidId_ShouldUpdatePersistedCurvePointItem()
        {
            var command = new UpdateCurvePointItemCommand
            {
                Id = 1,
                AsOfDate = new DateTime(2019, 01, 20),
                CurveId = 2,
                Term = 4,
                Value = 5
            };

            var handler = new UpdateCurvePointItemCommand.UpdateCurvePointItemCommandHandler(dbContext, mapper);

            await handler.Handle(command, CancellationToken.None);

            var entity = dbContext.CurvePoint.Find(command.Id);

            Assert.NotNull(entity);
            Assert.Equal(command.AsOfDate, entity.AsOfDate);
            Assert.Equal(command.CurveId, entity.CurveId);
            Assert.Equal(command.Term, entity.Term);
            Assert.Equal(command.Value, entity.Value);
        }

        [Fact]
        public async Task Handle_InvalidId_ThrowsException()
        {
            var command = new UpdateCurvePointItemCommand
            {
                Id = 22,
                AsOfDate = new DateTime(2019, 01, 20),
                CurveId = 2,
                Term = 4,
                Value = 5
            };

            var handler = new UpdateCurvePointItemCommand.UpdateCurvePointItemCommandHandler(dbContext, mapper);

            await Assert.ThrowsAsync<NotFoundException>(() =>
                handler.Handle(command, CancellationToken.None));
        }
    }
}
