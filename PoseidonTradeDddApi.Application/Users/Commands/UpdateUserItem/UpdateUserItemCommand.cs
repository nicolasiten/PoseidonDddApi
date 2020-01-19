using MediatR;
using PoseidonTradeDddApi.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace PoseidonTradeDddApi.Application.Users.Commands.UpdateUserItem
{
    public class UpdateUserItemCommand : IRequest
    {
        public string UserId { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool Admin { get; set; }

        public class UpdateUserItemCommandHandler : IRequestHandler<UpdateUserItemCommand>
        {
            private readonly IIdentityService _identityService;

            public UpdateUserItemCommandHandler(IIdentityService identityService)
            {
                _identityService = identityService;
            }

            public async Task<Unit> Handle(UpdateUserItemCommand request, CancellationToken cancellationToken)
            {
                await _identityService.UpdateUserAsync(
                    request.UserId,
                    request.FullName,
                    request.Email,
                    request.Password,
                    request.Admin);

                return Unit.Value;
            }
        }
    }
}
