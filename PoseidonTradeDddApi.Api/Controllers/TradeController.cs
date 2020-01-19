using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PoseidonTradeDddApi.Application.Trades.Commands.CreateTradeItem;
using PoseidonTradeDddApi.Application.Trades.Commands.DeleteTradeItem;
using PoseidonTradeDddApi.Application.Trades.Commands.UpdateTradeItem;
using PoseidonTradeDddApi.Application.Trades.Queries.GetAllTrades;
using PoseidonTradeDddApi.Application.Trades.Queries.GetTrade;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoseidonTradeDddApi.Api.Controllers
{
    [Authorize]
    public class TradeController : ApiController
    {
        /// <summary>
        /// Retrieve the trade by Id.
        /// </summary>
        /// <param name="id">The id of the desired trade.</param>
        /// <returns>The desired TradeModel.</returns>
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

        /// <summary>
        /// Retrieve all trades.
        /// </summary>
        /// <returns>All TradeModels.</returns>
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<List<TradeModel>>> GetAll()
        {
            return (await Mediator.Send(new GetAllTradesQuery())).ToList();
        }

        /// <summary>
        /// Create a new trade item.
        /// </summary>
        /// <param name="command">CreateTradeItemCommand to create the trade item</param>
        /// <returns>Number of items added.</returns>
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateTradeItemCommand command)
        {
            return await Mediator.Send(command);
        }

        /// <summary>
        /// Update an existing trade item.
        /// </summary>
        /// <param name="id">id of the trade item to update</param>
        /// <param name="command">UpdateTradeItemCommand to update the trade item</param>
        /// <returns></returns>
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

        /// <summary>
        /// Deletes an existing trade item.
        /// </summary>
        /// <param name="id">id of the trade item to delete</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteTradeItemCommand { TradeId = id });

            return NoContent();
        }
    }
}
