using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PoseidonTradeDddApi.Application.Curves.Commands.CreateCurvePointItem;
using PoseidonTradeDddApi.Application.Curves.Commands.DeleteCurvePointItem;
using PoseidonTradeDddApi.Application.Curves.Commands.UpdateCurvePointItem;
using PoseidonTradeDddApi.Application.Curves.Queries.GetAllCurvePoints;
using PoseidonTradeDddApi.Application.Curves.Queries.GetCurvePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoseidonTradeDddApi.Api.Controllers
{
    [Authorize]
    public class CurvePointController : ApiController
    {
        /// <summary>
        /// Retrieve the curvepoint by Id.
        /// </summary>
        /// <param name="id">The id of the desired curvepoint.</param>
        /// <returns>The desired CurvePointModel.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<CurvePointModel>> Get(int id)
        {
            var curvePointModel = await Mediator.Send(new GetCurvePointQuery { Id = id });

            if (curvePointModel == null)
            {
                return new NotFoundResult();
            }

            return curvePointModel;
        }

        /// <summary>
        /// Retrieve all curvepoints.
        /// </summary>
        /// <returns>All CuvePointModels.</returns>
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<List<CurvePointModel>>> GetAll()
        {
            return (await Mediator.Send(new GetAllCurvePointsQuery())).ToList();
        }

        private IRequest<object> GetAllCurvePointsQuery()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Create a new curvepoint item.
        /// </summary>
        /// <param name="command">CreateCurvePointItemCommand to create the curvepoint item</param>
        /// <returns>Number of items added.</returns>
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateCurvePointItemCommand command)
        {
            return await Mediator.Send(command);
        }

        /// <summary>
        /// Update an existing curvepoint item.
        /// </summary>
        /// <param name="id">id of the curvepoint item to update</param>
        /// <param name="command">UpdateCurvePointItemCommand to update the curvepoint item</param>
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateCurvePointItemCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        /// <summary>
        /// Deletes an existing curvepoint item.
        /// </summary>
        /// <param name="id">id of the curvepoint item to delete</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteCurvePointItemCommand { Id = id });

            return NoContent();
        }
    }
}
