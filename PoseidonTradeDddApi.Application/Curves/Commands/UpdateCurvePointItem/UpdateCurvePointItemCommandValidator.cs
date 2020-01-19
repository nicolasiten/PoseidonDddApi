using FluentValidation;

namespace PoseidonTradeDddApi.Application.Curves.Commands.UpdateCurvePointItem
{
    public class UpdateCurvePointItemCommandValidator : AbstractValidator<UpdateCurvePointItemCommand>
    {
        public UpdateCurvePointItemCommandValidator()
        {
            RuleFor(c => c.Id)
                .GreaterThan(0);

            RuleFor(c => c.Term)
                .GreaterThan(0);

            RuleFor(c => c.Value)
                .GreaterThan(0);
        }
    }
}
