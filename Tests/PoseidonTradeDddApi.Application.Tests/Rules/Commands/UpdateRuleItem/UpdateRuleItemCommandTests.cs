using PoseidonTradeDddApi.Application.Common.Exceptions;
using PoseidonTradeDddApi.Application.Rules.Commands.UpdateRuleItem;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PoseidonTradeDddApi.Application.Tests.Rules.Commands.UpdateRuleItem
{
    public class UpdateRuleItemCommandTests : ApplicationTestBase
    {
        [Fact]
        public async Task Handle_ValidId_ShouldUpdatePersistedRuleItem()
        {
            var command = new UpdateRuleItemCommand
            {
                Id = 1,
                Description = "Descriptions",
                Json = "Jsons",
                Name = "Names",
                SqlPart = "Sqls",
                SqlStr = "Sqlstrs",
                Template = "Templates"
            };

            var handler = new UpdateRuleItemCommand.UpdateRuleItemCommandHandler(dbContext, mapper);

            await handler.Handle(command, CancellationToken.None);

            var entity = dbContext.RuleName.Find(command.Id);

            Assert.NotNull(entity);
            Assert.Equal(command.Description, entity.Description);
            Assert.Equal(command.Json, entity.Json);
            Assert.Equal(command.Name, entity.Name);
            Assert.Equal(command.SqlPart, entity.SqlPart);
            Assert.Equal(command.SqlStr, entity.SqlStr);
            Assert.Equal(command.Template, entity.Template);
        }

        [Fact]
        public async Task Handle_InvalidId_ThrowsException()
        {
            var command = new UpdateRuleItemCommand
            {
                Id = 65,
                Description = "Descriptions",
                Json = "Jsons",
                Name = "Names",
                SqlPart = "Sqls",
                SqlStr = "Sqlstrs",
                Template = "Templates"
            };

            var handler = new UpdateRuleItemCommand.UpdateRuleItemCommandHandler(dbContext, mapper);

            await Assert.ThrowsAsync<NotFoundException>(() =>
                handler.Handle(command, CancellationToken.None));
        }
    }
}
