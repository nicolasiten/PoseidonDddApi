﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PoseidonTradeDddApi.Application.Bids.Commands.CreateBidItem;
using PoseidonTradeDddApi.Application.Bids.Queries.GetBid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoseidonTradeDddApi.Api.Controllers
{
    [Authorize]
    public class BidController : ApiController
    {
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

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateBidItemCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task Update()
        {

        }

        [HttpDelete("{id}")]
        public async Task Delete()
        {
 
        }
    }
}