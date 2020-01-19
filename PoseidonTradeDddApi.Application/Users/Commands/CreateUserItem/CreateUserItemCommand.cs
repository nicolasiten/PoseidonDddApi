using MediatR;
using PoseidonTradeDddApi.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace PoseidonTradeDddApi.Application.Users.Commands.CreateUserItem
{
    public class CreateUserItemCommand : IRequest<string>
    {
        public string FullName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool Admin { get; set; }

        public class CreateUserItemCommandHandler : IRequestHandler<CreateUserItemCommand, string>
        {
            private readonly IIdentityService _identityService;

            public CreateUserItemCommandHandler(IIdentityService identityService)
            {
                _identityService = identityService;
            }

            public async Task<string> Handle(CreateUserItemCommand request, CancellationToken cancellationToken)
            {
                return (await _identityService.CreateUserAsync(request.FullName, request.Email, request.Password, request.Admin)).UserId;
            }
        }
    }
}
