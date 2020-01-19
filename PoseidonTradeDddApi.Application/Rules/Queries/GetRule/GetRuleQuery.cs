using AutoMapper;
using MediatR;
using PoseidonTradeDddApi.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace PoseidonTradeDddApi.Application.Rules.Queries.GetRule
{
    public class GetRuleQuery : IRequest<RuleModel>
    {
        public int Id { get; set; }

        public class GetRuleQueryHandler : IRequestHandler<GetRuleQuery, RuleModel>
        {
            private readonly IApplicationDbContext _dbContext;
            private readonly IMapper _mapper;

            public GetRuleQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<RuleModel> Handle(GetRuleQuery request, CancellationToken cancellationToken)
            {
                var ruleEntity = await _dbContext.RuleName
                    .FindAsync(request.Id);

                return _mapper.Map<RuleModel>(ruleEntity);
            }
        }
    }
}
