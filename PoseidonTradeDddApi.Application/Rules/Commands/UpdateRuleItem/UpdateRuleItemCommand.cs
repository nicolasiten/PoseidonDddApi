using AutoMapper;
using MediatR;
using PoseidonTradeDddApi.Application.Common.Exceptions;
using PoseidonTradeDddApi.Application.Common.Interfaces;
using PoseidonTradeDddApi.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace PoseidonTradeDddApi.Application.Rules.Commands.UpdateRuleItem
{
    public class UpdateRuleItemCommand : IRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Json { get; set; }

        public string Template { get; set; }

        public string SqlStr { get; set; }

        public string SqlPart { get; set; }

        public class UpdateRuleItemCommandHandler : IRequestHandler<UpdateRuleItemCommand>
        {
            private readonly IApplicationDbContext _dbContext;
            private readonly IMapper _mapper;

            public UpdateRuleItemCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(UpdateRuleItemCommand request, CancellationToken cancellationToken)
            {
                var ruleEntity = await _dbContext.RuleName
                    .FindAsync(request.Id);

                if (ruleEntity == null)
                {
                    throw new NotFoundException(nameof(RuleName), request.Id);
                }

                _mapper.Map(request, ruleEntity);

                await _dbContext.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
