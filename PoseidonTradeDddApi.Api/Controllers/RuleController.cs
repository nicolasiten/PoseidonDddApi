using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PoseidonTradeDddApi.Application.Bids.Commands.CreateRuleItem;
using PoseidonTradeDddApi.Application.Bids.Queries.GetRule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoseidonTradeDddApi.Api.Controllers
{
    [Authorize]
    public class RuleController : ApiController
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<RuleModel>> Get(int id)
        {
            var ruleModel = await Mediator.Send(new GetRuleQuery { Id = id });

            if (ruleModel == null)
            {
                return NotFound();
            }

            return ruleModel;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateRuleItemCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update()
        {
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {

        }
    }
}
