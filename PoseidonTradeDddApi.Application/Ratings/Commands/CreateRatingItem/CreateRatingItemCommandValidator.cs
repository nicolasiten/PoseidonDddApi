using FluentValidation;

namespace PoseidonTradeDddApi.Application.Ratings.Commands.CreateRatingItem
{
    public class CreateRatingItemCommandValidator : AbstractValidator<CreateRatingItemCommand>
    {
        public CreateRatingItemCommandValidator()
        {
            RuleFor(r => r.MoodysRating)
                .MaximumLength(125);

            RuleFor(r => r.SandPrating)
                .MaximumLength(125);

            RuleFor(r => r.FitchRating)
                .MaximumLength(125);
        }
    }
}
