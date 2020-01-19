using FluentValidation;

namespace PoseidonTradeDddApi.Application.Ratings.Commands.UpdateRatingItem
{
    public class UpdateRatingItemCommandValidator : AbstractValidator<UpdateRatingItemCommand>
    {
        public UpdateRatingItemCommandValidator()
        {
            RuleFor(r => r.Id)
                .GreaterThan(0);

            RuleFor(r => r.MoodysRating)
                .MaximumLength(125);

            RuleFor(r => r.SandPrating)
                .MaximumLength(125);

            RuleFor(r => r.FitchRating)
                .MaximumLength(125);
        }
    }
}
