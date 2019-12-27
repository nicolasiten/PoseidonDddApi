using Microsoft.AspNetCore.Identity;
using PoseidonTradeDddApi.Application.Interfaces;
using PoseidonTradeDddApi.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoseidonTradeDddApi.Infrastructure.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public IdentityService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<(Result Result, string UserId)> CreateUserAsync(string fullName, string userName, string password)
        {
            var user = new ApplicationUser
            {
                FullName = fullName,
                UserName = userName,
                Email = userName
            };

            var result = await _userManager.CreateAsync(user, password);

            return (result.ToApplicationResult(), user.Id);
        }

        public async Task<Result> DeleteUserAsync(string userId)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

            if (user != null)
            {
                var result = await _userManager.DeleteAsync(user);

                return result.ToApplicationResult();
            }

            return Result.Success();
        }
    }
}
