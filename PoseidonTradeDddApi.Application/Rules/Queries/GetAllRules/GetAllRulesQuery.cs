using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PoseidonTradeDddApi.Application.Common.Interfaces;
using PoseidonTradeDddApi.Application.Rules.Queries.GetRule;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PoseidonTradeDddApi.Application.Rules.Queries.GetAllRules
{
    public class GetAllRulesQuery : IRequest<IEnumerable<RuleModel>>
    {
        public class GetAllRulesQueryHandler : IRequestHandler<GetAllRulesQuery, IEnumerable<RuleModel>>
        {
            private readonly IApplicationDbContext _dbContext;
            private readonly IMapper _mapper;

            public GetAllRulesQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<IEnumerable<RuleModel>> Handle(GetAllRulesQuery request, CancellationToken cancellationToken)
            {
                var ruleEntities = await _dbContext.RuleName.ToListAsync();

                return _mapper.Map<IEnumerable<RuleModel>>(ruleEntities);
            }
        }
    }
}
