using PoseidonTradeDddApi.Application.Common.Exceptions;
using PoseidonTradeDddApi.Application.Rules.Commands.DeleteRuleItem;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PoseidonTradeDddApi.Application.Tests.Rules.Commands.DeleteRuleItem
{
    public class DeleteRuleItemCommandTests : ApplicationTestBase
    {
        [Fact]
        public async Task Handle_ValidId_ShouldRemovePersistedRuleItem()
        {
            var command = new DeleteRuleItemCommand
            {
                Id = 1
            };

            var handler = new DeleteRuleItemCommand.DeleteRuleItemCommandHandler(dbContext);

            await handler.Handle(command, CancellationToken.None);

            var entity = dbContext.RuleName.Find(command.Id);

            Assert.Null(entity);
        }

        [Fact]
        public async Task Handle_InvalidId_ThrowsException()
        {
            var command = new DeleteRuleItemCommand
            {
                Id = 32
            };

            var handler = new DeleteRuleItemCommand.DeleteRuleItemCommandHandler(dbContext);

            await Assert.ThrowsAsync<NotFoundException>(() =>
                handler.Handle(command, CancellationToken.None));
        }
    }
}
