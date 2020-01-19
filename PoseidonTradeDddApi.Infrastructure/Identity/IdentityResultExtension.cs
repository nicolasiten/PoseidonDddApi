using Microsoft.AspNetCore.Identity;
using PoseidonTradeDddApi.Application.Common.Models;
using System.Linq;

namespace PoseidonTradeDddApi.Infrastructure.Identity
{
    public static class IdentityResultExtension
    {
        public static Result ToApplicationResult(this IdentityResult result)
        {
            return result.Succeeded
                ? Result.Success()
                : Result.Failure(result.Errors.Select(e => e.Description));
        }
    }
}
