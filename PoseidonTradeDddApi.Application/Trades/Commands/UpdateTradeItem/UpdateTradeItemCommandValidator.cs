using FluentValidation;

namespace PoseidonTradeDddApi.Application.Trades.Commands.UpdateTradeItem
{
    public class UpdateTradeItemCommandValidator : AbstractValidator<UpdateTradeItemCommand>
    {
        public UpdateTradeItemCommandValidator()
        {
            RuleFor(t => t.TradeId)
                .GreaterThan(0);

            RuleFor(t => t.Account)
                .MaximumLength(30)
                .NotEmpty();

            RuleFor(t => t.Type)
                .MaximumLength(30)
                .NotEmpty();

            RuleFor(t => t.BuyQuantity)
                .GreaterThan(0);

            RuleFor(t => t.SellQuantity)
                .GreaterThan(0);

            RuleFor(t => t.BuyPrice)
                .GreaterThan(0);

            RuleFor(t => t.SellPrice)
                .GreaterThan(0);

            RuleFor(t => t.Security)
                .MaximumLength(125);

            RuleFor(t => t.Status)
                .MaximumLength(10);

            RuleFor(t => t.Trader)
                .MaximumLength(125);

            RuleFor(t => t.Benchmark)
                .MaximumLength(125);

            RuleFor(t => t.Book)
                .MaximumLength(125);

            RuleFor(t => t.DealName)
                .MaximumLength(125);

            RuleFor(t => t.DealType)
                .MaximumLength(125);

            RuleFor(t => t.SourceListId)
                .MaximumLength(125);

            RuleFor(t => t.Side)
                .MaximumLength(125);
        }
    }
}
