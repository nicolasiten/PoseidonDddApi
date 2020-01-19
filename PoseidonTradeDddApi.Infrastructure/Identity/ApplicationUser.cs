using Microsoft.AspNetCore.Identity;

namespace PoseidonTradeDddApi.Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}
