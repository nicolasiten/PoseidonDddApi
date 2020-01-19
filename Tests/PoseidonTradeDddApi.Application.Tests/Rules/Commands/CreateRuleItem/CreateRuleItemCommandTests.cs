using PoseidonTradeDddApi.Application.Rules.Commands.CreateRuleItem;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PoseidonTradeDddApi.Application.Tests.Rules.Commands.CreateRuleItem
{
    public class CreateRuleItemCommandTests : ApplicationTestBase
    {
        [Fact]
        public async Task Handle_ShouldPersistRuleItem()
        {
            var command = new CreateRuleItemCommand
            {
                Description = "Description",
                Json = "Json",
                Name = "Name",
                SqlPart = "Sql",
                SqlStr = "Sqlstr",
                Template = "Template"
            };

            var handler = new CreateRuleItemCommand.CreateRuleItemCommandHandler(dbContext, mapper);

            await handler.Handle(command, CancellationToken.None);

            var entity = dbContext.RuleName.Last();

            Assert.NotNull(entity);
            Assert.Equal(command.Description, entity.Description);
            Assert.Equal(command.Json, entity.Json);
            Assert.Equal(command.Name, entity.Name);
            Assert.Equal(command.SqlPart, entity.SqlPart);
            Assert.Equal(command.SqlStr, entity.SqlStr);
            Assert.Equal(command.Template, entity.Template);
        }
    }
}
