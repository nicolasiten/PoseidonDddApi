using IdentityModel;
using Microsoft.AspNetCore.Identity;
using PoseidonTradeDddApi.Application.Common.Exceptions;
using PoseidonTradeDddApi.Application.Common.Interfaces;
using PoseidonTradeDddApi.Application.Common.Models;
using PoseidonTradeDddApi.Application.Users.Queries.GetUser;
using PoseidonTradeDddApi.Domain.Constants;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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

        public async Task<(Result Result, string UserId)> CreateUserAsync(string fullName, string userName, string password, bool admin)
        {
            var user = new ApplicationUser
            {
                FullName = fullName,
                UserName = userName,
                Email = userName
            };

            var result = await _userManager.CreateAsync(user, password);

            if (admin && result.Succeeded)
            {
                await _userManager.AddClaimAsync(user, new Claim(JwtClaimTypes.Role, RoleNames.Admin));
            }

            return (result.ToApplicationResult(), user.Id);
        }

        public async Task<Result> UpdateUserAsync(string userId, string fullName, string userName, string password, bool admin)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                throw new NotFoundException(nameof(ApplicationUser), userId);
            }

            user.FullName = fullName;
            user.UserName = userName;
            user.Email = userName;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, password);

            var result = await _userManager.UpdateAsync(user);

            bool isAdmin = await IsAdminAsync(user);

            if (admin && !isAdmin)
            {
                await _userManager.AddClaimAsync(user, new Claim(JwtClaimTypes.Role, RoleNames.Admin));
            }

            if (!admin && isAdmin)
            {
                await _userManager.RemoveClaimAsync(user, new Claim(JwtClaimTypes.Role, RoleNames.Admin));
            }

            return result.ToApplicationResult();
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

        public async Task<UserModel> GetUserAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);

            if (user != null)
            {
                var userModel = await MapApplicationUserToModelAsync(user);

                return userModel;
            }

            return null;
        }

        public async Task<IEnumerable<UserModel>> GetAllUsersAsync()
        {
            List<UserModel> userModels = new List<UserModel>();

            var users = _userManager.Users.ToList();

            foreach (var user in users)
            {
                userModels.Add(await MapApplicationUserToModelAsync(user));
            }

            return userModels;
        }

        private async Task<bool> IsAdminAsync(ApplicationUser user)
        {
            return (await _userManager.GetClaimsAsync(user))
                        .Where(c => c.Type == JwtClaimTypes.Role && c.Value == RoleNames.Admin)
                        .Any();
        }

        private async Task<UserModel> MapApplicationUserToModelAsync(ApplicationUser user)
        {
            return new UserModel
            {
                UserId = user.Id,
                FullName = user.FullName,
                UserName = user.UserName,
                Email = user.Email,
                RoleClaims = (await _userManager.GetClaimsAsync(user))
                        .Where(c => c.Type == JwtClaimTypes.Role)
                        .Select(c => c.Value)
            };
        }
    }
}
