using FluentValidation;

namespace PoseidonTradeDddApi.Application.Users.Commands.CreateUserItem
{
    public class CreateUserItemCommandValidator : AbstractValidator<CreateUserItemCommand>
    {
        public CreateUserItemCommandValidator()
        {
            RuleFor(u => u.Email)
                .MaximumLength(256)
                .EmailAddress()
                .NotEmpty();
        }
    }
}
