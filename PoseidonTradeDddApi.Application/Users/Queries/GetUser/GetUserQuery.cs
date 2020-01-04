using MediatR;
using PoseidonTradeDddApi.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
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

            public GetUserQueryHandler(IIdentityService identityService)
            {
                _identityService = identityService;
            }

            public async Task<UserModel> Handle(GetUserQuery request, CancellationToken cancellationToken)
            {
                return await _identityService.GetUserAsync(request.UserName);
            }
        }
    }
}
