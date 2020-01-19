using FluentValidation;

namespace PoseidonTradeDddApi.Application.Rules.Commands.CreateRuleItem
{
    public class CreateRuleItemCommandValidator : AbstractValidator<CreateRuleItemCommand>
    {
        public CreateRuleItemCommandValidator()
        {
            RuleFor(r => r.Name)
                .MaximumLength(125);

            RuleFor(r => r.Description)
                .MaximumLength(125);

            RuleFor(r => r.Json)
                .MaximumLength(125);

            RuleFor(r => r.Template)
                .MaximumLength(125);

            RuleFor(r => r.SqlStr)
                .MaximumLength(125);

            RuleFor(r => r.SqlPart)
                .MaximumLength(125);
        }
    }
}
