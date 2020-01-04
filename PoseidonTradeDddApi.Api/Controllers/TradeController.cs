using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
