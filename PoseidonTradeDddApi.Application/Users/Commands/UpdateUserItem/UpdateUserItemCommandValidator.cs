using FluentValidation;

namespace PoseidonTradeDddApi.Application.Users.Commands.UpdateUserItem
{
    public class UpdateUserItemCommandValidator : AbstractValidator<UpdateUserItemCommand>
    {
        public UpdateUserItemCommandValidator()
        {
            RuleFor(u => u.UserId)
                .NotEmpty();

            RuleFor(u => u.Email)
                .MaximumLength(256)
                .EmailAddress()
                .NotEmpty();
        }
    }
}
