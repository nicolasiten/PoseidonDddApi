using IdentityModel;
using Microsoft.AspNetCore.Identity;
using PoseidonTradeDddApi.Domain.Constants;
using PoseidonTradeDddApi.Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PoseidonTradeDddApi.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedIdentityAsync(UserManager<ApplicationUser> userManager)
        {
            if ((await userManager.FindByEmailAsync("admin@poseidon.com")) == null)
            {
                var adminUser = new ApplicationUser
                {
                    UserName = "admin@poseidon.com",
                    Email = "admin@poseidon.com",
                };

                if ((await userManager.CreateAsync(adminUser, "Poseidon1!")).Succeeded)
                {
                    await userManager.AddClaimAsync(adminUser, new Claim(JwtClaimTypes.Role, RoleNames.Admin));
                }
            }

            if ((await userManager.FindByEmailAsync("user@poseidon.com")) == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "user@poseidon.com",
                    Email = "user@poseidon.com"
                };

                await userManager.CreateAsync(user, "Poseidon1!");
            }
        }
    }
}
