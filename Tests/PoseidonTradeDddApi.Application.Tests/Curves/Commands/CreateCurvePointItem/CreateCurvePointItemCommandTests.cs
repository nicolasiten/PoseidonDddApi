using PoseidonTradeDddApi.Application.Curves.Commands.CreateCurvePointItem;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PoseidonTradeDddApi.Application.Tests.Curves.Commands.CreateCurvePointItem
{
    public class CreateCurvePointItemCommandTests : ApplicationTestBase
    {
        [Fact]
        public async Task Handle_ShouldPersistCurvePointItem()
        {
            var command = new CreateCurvePointItemCommand
            {
                AsOfDate = new DateTime(2020, 01, 10),
                CurveId = 1,
                Term = 1,
                Value = 2
            };

            var handler = new CreateCurvePointItemCommand.CreateCurvePointItemCommandHandler(dbContext, mapper);

            await handler.Handle(command, CancellationToken.None);

            var entity = dbContext.CurvePoint.Last();

            Assert.NotNull(entity);
            Assert.Equal(command.AsOfDate, entity.AsOfDate);
            Assert.Equal(command.CurveId, entity.CurveId);
            Assert.Equal(command.Term, entity.Term);
            Assert.Equal(command.Value, entity.Value);
        }
    }
}
