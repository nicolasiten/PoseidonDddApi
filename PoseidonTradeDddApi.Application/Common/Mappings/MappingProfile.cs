using AutoMapper;
using PoseidonTradeDddApi.Application.Bids.Commands.CreateBidItem;
using PoseidonTradeDddApi.Application.Rules.Commands.CreateRuleItem;
using PoseidonTradeDddApi.Application.Bids.Commands.UpdateBidItem;
using PoseidonTradeDddApi.Application.Rules.Commands.UpdateRuleItem;
using PoseidonTradeDddApi.Application.Bids.Queries.GetBid;
using PoseidonTradeDddApi.Application.Curve.Queries.GetCurvePoint;
using PoseidonTradeDddApi.Application.Rules.Queries.GetRule;
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
            CreateMap<UpdateRuleItemCommand, RuleName>();

            CreateMap<CurvePoint, CurvePointModel>();
        }
    }
}
