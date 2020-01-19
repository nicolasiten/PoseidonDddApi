using MediatR;
using PoseidonTradeDddApi.Application.Common.Interfaces;
using PoseidonTradeDddApi.Application.Users.Queries.GetUser;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PoseidonTradeDddApi.Application.Users.Queries.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<IEnumerable<UserModel>>
    {
        public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<UserModel>>
        {
            private readonly IIdentityService _identityService;

            public GetAllUsersQueryHandler(IIdentityService identityService)
            {
                _identityService = identityService;
            }

            public async Task<IEnumerable<UserModel>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
            {
                return await _identityService.GetAllUsersAsync();
            }
        }
    }
}
