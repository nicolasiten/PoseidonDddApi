using IdentityModel;
using Microsoft.AspNetCore.Http;
using PoseidonTradeDddApi.Application.Common.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace PoseidonTradeDddApi.Api.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserName = httpContextAccessor.HttpContext?.User?.FindFirstValue(JwtClaimTypes.Email);
            RoleClaims = httpContextAccessor.HttpContext?.User?.FindAll(JwtClaimTypes.Role).Select(c => c.Value);
        }

        public string UserName { get; }

        public IEnumerable<string> RoleClaims { get; }
    }
}
