using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PoseidonTradeDddApi.Application.Ratings.Commands.CreateRatingItem;
using PoseidonTradeDddApi.Application.Ratings.Commands.UpdateRatingItem;
using PoseidonTradeDddApi.Application.Ratings.Queries.GetRating;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoseidonTradeDddApi.Api.Controllers
{
    [Authorize]
    public class RatingController : ApiController
    {
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

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateRatingItemCommand command)
        {
            return await Mediator.Send(command);
        }

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

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {

        }
    }
}
