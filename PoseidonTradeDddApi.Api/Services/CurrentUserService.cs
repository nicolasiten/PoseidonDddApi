using Microsoft.AspNetCore.Http;
using PoseidonTradeDddApi.Application.Common.Interfaces;
using System.Security.Claims;

namespace PoseidonTradeDddApi.Api.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserName = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public string UserName { get; }
    }
}
