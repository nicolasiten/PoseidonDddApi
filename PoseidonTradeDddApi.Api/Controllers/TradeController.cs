using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PoseidonTradeDddApi.Application.Trades.Commands.CreateTradeItem;
using PoseidonTradeDddApi.Application.Trades.Commands.DeleteTradeItem;
using PoseidonTradeDddApi.Application.Trades.Commands.UpdateTradeItem;
using PoseidonTradeDddApi.Application.Trades.Queries.GetTrade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoseidonTradeDddApi.Api.Controllers
{
    [Authorize]
    public class TradeController : ApiController
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<TradeModel>> Get(int id)
        {
            var tradeModel = await Mediator.Send(new GetTradeQuery { TradeId = id });

            if (tradeModel == null)
            {
                return new NotFoundResult();
            }

            return tradeModel;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateTradeItemCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateTradeItemCommand command)
        {
            if (id != command.TradeId)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteTradeItemCommand { TradeId = id });

            return NoContent();
        }
    }
}
