using MediatR;
using PoseidonTradeDddApi.Application.Bids.Queries.GetBid;
using System;
using System.Collections.Generic;
using System.Text;

namespace PoseidonTradeDddApi.Application.Bids.Queries.GetAllBids
{
    public class GetAllBidsQuery : IRequest<IEnumerable<BidModel>>
    {
    }
}
