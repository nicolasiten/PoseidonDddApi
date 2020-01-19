using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PoseidonTradeDddApi.Application.Ratings.Commands.CreateRatingItem;
using PoseidonTradeDddApi.Application.Ratings.Commands.DeleteRatingItem;
using PoseidonTradeDddApi.Application.Ratings.Commands.UpdateRatingItem;
using PoseidonTradeDddApi.Application.Ratings.Queries.GetAllRatings;
using PoseidonTradeDddApi.Application.Ratings.Queries.GetRating;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoseidonTradeDddApi.Api.Controllers
{
    [Authorize]
    public class RatingController : ApiController
    {
        /// <summary>
        /// Retrieve the rating by Id.
        /// </summary>
        /// <param name="id">The id of the desired rating.</param>
        /// <returns>The desired RatingModel.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<RatingModel>> Get(int id)
        {
            var ratingModel = await Mediator.Send(new GetRatingQuery { Id = id });

            if (ratingModel == null)
            {
                return new NotFoundResult();
            }

            return ratingModel;
        }

        /// <summary>
        /// Retrieve all ratings
        /// </summary>
        /// <returns>All RatingModels.</returns>
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<List<RatingModel>>> GetAll()
        {
            return (await Mediator.Send(new GetAllRatingsQuery())).ToList();
        }

        /// <summary>
        /// Create a new rating item.
        /// </summary>
        /// <param name="command">CreateRatingItemCommand to create the rating item</param>
        /// <returns>Number of items added.</returns>
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateRatingItemCommand command)
        {
            return await Mediator.Send(command);
        }

        /// <summary>
        /// Update an existing rating item.
        /// </summary>
        /// <param name="id">id of the rating item to update</param>
        /// <param name="command">UpdateRatingItemCommand to update the rating item</param>
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateRatingItemCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        /// <summary>
        /// Deletes an existing rating item.
        /// </summary>
        /// <param name="id">id of the rating item to delete</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteRatingItemCommand { Id = id });

            return NoContent();
        }
    }
}
