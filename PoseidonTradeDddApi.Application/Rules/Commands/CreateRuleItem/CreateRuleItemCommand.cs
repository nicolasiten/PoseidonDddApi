using AutoMapper;
using MediatR;
using PoseidonTradeDddApi.Application.Common.Interfaces;
using PoseidonTradeDddApi.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace PoseidonTradeDddApi.Application.Rules.Commands.CreateRuleItem
{
    public class CreateRuleItemCommand : IRequest<int>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Json { get; set; }

        public string Template { get; set; }

        public string SqlStr { get; set; }

        public string SqlPart { get; set; }

        public class CreateRuleItemCommandHandler : IRequestHandler<CreateRuleItemCommand, int>
        {
            private readonly IApplicationDbContext _dbContext;
            private readonly IMapper _mapper;

            public CreateRuleItemCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<int> Handle(CreateRuleItemCommand request, CancellationToken cancellationToken)
            {
                var ruleEntity = _mapper.Map<RuleName>(request);

                _dbContext.RuleName.Add(ruleEntity);

                return await _dbContext.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
