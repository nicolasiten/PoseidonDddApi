using Microsoft.AspNetCore.Mvc;
using PoseidonTradeDddApi.Application.Curve.Queries.GetCurvePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoseidonTradeDddApi.Api.Controllers
{
    public class CurvePointController : ApiController
    {
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

        [HttpPost]
        public async Task<ActionResult<int>> Create()
        {
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id)
        {

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {

        }
    }
}
