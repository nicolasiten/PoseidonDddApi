using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PoseidonTradeDddApi.Application.Rules.Commands.CreateRuleItem;
using PoseidonTradeDddApi.Application.Rules.Commands.DeleteRuleItem;
using PoseidonTradeDddApi.Application.Rules.Commands.UpdateRuleItem;
using PoseidonTradeDddApi.Application.Rules.Queries.GetAllRules;
using PoseidonTradeDddApi.Application.Rules.Queries.GetRule;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoseidonTradeDddApi.Api.Controllers
{
    [Authorize]
    public class RuleController : ApiController
    {
        /// <summary>
        /// Retrieve the rule by Id.
        /// </summary>
        /// <param name="id">The id of the desired rule.</param>
        /// <returns>The desired RuleModel.</returns>
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

        /// <summary>
        /// Retrieve all rules.
        /// </summary>
        /// <returns>All RuleModels.</returns>
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<List<RuleModel>>> GetAll()
        {
            return (await Mediator.Send(new GetAllRulesQuery())).ToList();
        }

        /// <summary>
        /// Create a new rule item.
        /// </summary>
        /// <param name="command">CreateRuleItemCommand to create the rule item</param>
        /// <returns>Number of items added.</returns>
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateRuleItemCommand command)
        {
            return await Mediator.Send(command);
        }

        /// <summary>
        /// Update an existing rule item.
        /// </summary>
        /// <param name="id">id of the rule item to update</param>
        /// <param name="command">UpdateRuleItemCommand to update the rule item</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateRuleItemCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        /// <summary>
        /// Deletes an existing rule item.
        /// </summary>
        /// <param name="id">id of the rule item to delete</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteRuleItemCommand { Id = id });

            return NoContent();
        }
    }
}
