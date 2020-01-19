using PoseidonTradeDddApi.Application.Common.Models;
using PoseidonTradeDddApi.Application.Users.Queries.GetUser;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PoseidonTradeDddApi.Application.Common.Interfaces
{
    public interface IIdentityService
    {
        Task<(Result Result, string UserId)> CreateUserAsync(string fullName, string userName, string password, bool admin);

        Task<Result> UpdateUserAsync(string userId, string fullName, string userName, string password, bool admin);

        Task<Result> DeleteUserAsync(string userId);

        Task<UserModel> GetUserAsync(string userName);

        Task<IEnumerable<UserModel>> GetAllUsersAsync();
    }
}
