using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PoseidonTradeDddApi.Application.Bids.Commands.CreateBidItem;
using PoseidonTradeDddApi.Application.Bids.Commands.DeleteBidItem;
using PoseidonTradeDddApi.Application.Bids.Commands.UpdateBidItem;
using PoseidonTradeDddApi.Application.Bids.Queries.GetAllBids;
using PoseidonTradeDddApi.Application.Bids.Queries.GetBid;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoseidonTradeDddApi.Api.Controllers
{
    [Authorize]
    public class BidController : ApiController
    {
        /// <summary>
        /// Retrieve the bid by Id.
        /// </summary>
        /// <param name="id">The id of the desired bid.</param>
        /// <returns>The desired BidModel.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<BidModel>> Get(int id)
        {
            var bidModel = await Mediator.Send(new GetBidQuery { BidListId = id });

            if (bidModel == null)
            {
                return new NotFoundResult();
            }

            return bidModel;
        }

        /// <summary>
        /// Retrieve all bids.
        /// </summary>
        /// <returns>All BidModels.</returns>
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<List<BidModel>>> GetAll()
        {
            return (await Mediator.Send(new GetAllBidsQuery())).ToList();
        }

        /// <summary>
        /// Create a new bid item.
        /// </summary>
        /// <param name="command">CreateBidItemCommand to create the bid item</param>
        /// <returns>Number of items added.</returns>
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateBidItemCommand command)
        {
            return await Mediator.Send(command);
        }

        /// <summary>
        /// Update an existing bid item.
        /// </summary>
        /// <param name="id">id of the bid item to update</param>
        /// <param name="command">UpdateBidItemCommand to update the bid item</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateBidItemCommand command)
        {
            if (id != command.BidListId)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        /// <summary>
        /// Deletes an existing bid item.
        /// </summary>
        /// <param name="id">id of the bid item to delete</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteBidItemCommand { BidListId = id });

            return NoContent();
        }
    }
}
