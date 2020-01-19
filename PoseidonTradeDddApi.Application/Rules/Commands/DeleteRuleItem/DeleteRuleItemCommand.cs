using MediatR;
using PoseidonTradeDddApi.Application.Common.Exceptions;
using PoseidonTradeDddApi.Application.Common.Interfaces;
using PoseidonTradeDddApi.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace PoseidonTradeDddApi.Application.Rules.Commands.DeleteRuleItem
{
    public class DeleteRuleItemCommand : IRequest
    {
        public int Id { get; set; }

        public class DeleteRuleItemCommandHandler : IRequestHandler<DeleteRuleItemCommand>
        {
            private readonly IApplicationDbContext _dbContext;

            public DeleteRuleItemCommandHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<Unit> Handle(DeleteRuleItemCommand request, CancellationToken cancellationToken)
            {
                var ruleEntity = await _dbContext.RuleName
                    .FindAsync(request.Id);

                if (ruleEntity == null)
                {
                    throw new NotFoundException(nameof(RuleName), request.Id);
                }

                _dbContext.RuleName.Remove(ruleEntity);

                await _dbContext.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
