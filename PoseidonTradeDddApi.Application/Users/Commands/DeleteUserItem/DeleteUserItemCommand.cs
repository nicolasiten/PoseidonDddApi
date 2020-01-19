using MediatR;
using PoseidonTradeDddApi.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace PoseidonTradeDddApi.Application.Users.Commands.DeleteUserItem
{
    public class DeleteUserItemCommand : IRequest
    {
        public string UserId { get; set; }

        public class DeleteUserItemCommandHandler : IRequestHandler<DeleteUserItemCommand>
        {
            private readonly IIdentityService _identityService;

            public DeleteUserItemCommandHandler(IIdentityService identityService)
            {
                _identityService = identityService;
            }

            public async Task<Unit> Handle(DeleteUserItemCommand request, CancellationToken cancellationToken)
            {
                await _identityService.DeleteUserAsync(request.UserId);

                return Unit.Value;
            }
        }
    }
}
