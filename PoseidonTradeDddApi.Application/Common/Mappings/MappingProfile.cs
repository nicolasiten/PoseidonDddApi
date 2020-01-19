using AutoMapper;
using PoseidonTradeDddApi.Application.Bids.Commands.CreateBidItem;
using PoseidonTradeDddApi.Application.Bids.Commands.UpdateBidItem;
using PoseidonTradeDddApi.Application.Bids.Queries.GetBid;
using PoseidonTradeDddApi.Application.Curves.Commands.CreateCurvePointItem;
using PoseidonTradeDddApi.Application.Curves.Commands.UpdateCurvePointItem;
using PoseidonTradeDddApi.Application.Curves.Queries.GetCurvePoint;
using PoseidonTradeDddApi.Application.Ratings.Commands.CreateRatingItem;
using PoseidonTradeDddApi.Application.Ratings.Commands.UpdateRatingItem;
using PoseidonTradeDddApi.Application.Ratings.Queries.GetRating;
using PoseidonTradeDddApi.Application.Rules.Commands.CreateRuleItem;
using PoseidonTradeDddApi.Application.Rules.Commands.UpdateRuleItem;
using PoseidonTradeDddApi.Application.Rules.Queries.GetRule;
using PoseidonTradeDddApi.Application.Trades.Commands.CreateTradeItem;
using PoseidonTradeDddApi.Application.Trades.Commands.UpdateTradeItem;
using PoseidonTradeDddApi.Application.Trades.Queries.GetTrade;
using PoseidonTradeDddApi.Domain.Entities;

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
            CreateMap<CreateCurvePointItemCommand, CurvePoint>();
            CreateMap<UpdateCurvePointItemCommand, CurvePoint>();

            CreateMap<Rating, RatingModel>();
            CreateMap<CreateRatingItemCommand, Rating>();
            CreateMap<UpdateRatingItemCommand, Rating>();

            CreateMap<Trade, TradeModel>();
            CreateMap<CreateTradeItemCommand, Trade>();
            CreateMap<UpdateTradeItemCommand, Trade>();
        }
    }
}
