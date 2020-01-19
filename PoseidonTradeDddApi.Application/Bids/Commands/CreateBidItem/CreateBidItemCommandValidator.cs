using FluentValidation;

namespace PoseidonTradeDddApi.Application.Bids.Commands.CreateBidItem
{
    public class CreateBidItemCommandValidator : AbstractValidator<CreateBidItemCommand>
    {
        public CreateBidItemCommandValidator()
        {
            RuleFor(b => b.Account)
                .MaximumLength(30)
                .NotEmpty();

            RuleFor(b => b.Type)
                .MaximumLength(30)
                .NotEmpty();

            RuleFor(b => b.BidQuantity)
                .GreaterThan(0);

            RuleFor(b => b.AskQuantity)
                .GreaterThan(0);

            RuleFor(b => b.Bid)
                .GreaterThan(0);

            RuleFor(b => b.Ask)
                .GreaterThan(0);

            RuleFor(b => b.Benchmark)
                .MaximumLength(125);

            RuleFor(b => b.Commentary)
                .MaximumLength(125);

            RuleFor(b => b.Security)
                .MaximumLength(125);

            RuleFor(b => b.Status)
                .MaximumLength(10);

            RuleFor(b => b.Trader)
                .MaximumLength(125);

            RuleFor(b => b.Book)
                .MaximumLength(125);

            RuleFor(b => b.DealName)
                .MaximumLength(125);

            RuleFor(b => b.DealType)
                .MaximumLength(125);

            RuleFor(b => b.SourceListId)
                .MaximumLength(125);

            RuleFor(b => b.Side)
                .MaximumLength(125);
        }
    }
}
