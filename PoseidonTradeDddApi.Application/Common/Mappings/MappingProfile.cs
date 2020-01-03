using AutoMapper;
using PoseidonTradeDddApi.Application.Bids.Commands.CreateBidItem;
using PoseidonTradeDddApi.Application.Bids.Commands.CreateRuleItem;
using PoseidonTradeDddApi.Application.Bids.Commands.UpdateBidItem;
using PoseidonTradeDddApi.Application.Bids.Queries.GetBid;
using PoseidonTradeDddApi.Application.Bids.Queries.GetRule;
using PoseidonTradeDddApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PoseidonTradeDddApi.Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BidList, BidModel>();
            CreateMap<CreateBidItemCommand, BidList>();
            CreateMap<UpdateBidItemCommand, BidList>();

            CreateMap<RuleName, RuleModel>();
            CreateMap<CreateRuleItemCommand, RuleName>();
        }
    }
}
