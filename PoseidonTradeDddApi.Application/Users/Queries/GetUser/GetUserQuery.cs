using MediatR;
using PoseidonTradeDddApi.Application.Common.Exceptions;
using PoseidonTradeDddApi.Application.Common.Interfaces;
using PoseidonTradeDddApi.Domain.Constants;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PoseidonTradeDddApi.Application.Users.Queries.GetUser
{
    public class GetUserQuery : IRequest<UserModel>
    {
        public string UserName { get; set; }

        public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserModel>
        {
            private readonly IIdentityService _identityService;
            private readonly ICurrentUserService _currentUserService;

            public GetUserQueryHandler(IIdentityService identityService, ICurrentUserService currentUserService)
            {
                _identityService = identityService;
                _currentUserService = currentUserService;
            }

            public async Task<UserModel> Handle(GetUserQuery request, CancellationToken cancellationToken)
            {
                if (!_currentUserService.RoleClaims.Contains(RoleNames.Admin) && request.UserName != _currentUserService.UserName)
                {
                    throw new ForbiddenException();
                }

                return await _identityService.GetUserAsync(request.UserName);
            }
        }
    }
}
