using PoseidonTradeDddApi.Application.Common.Models;
using PoseidonTradeDddApi.Application.Users.Queries.GetUser;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PoseidonTradeDddApi.Application.Common.Interfaces
{
    public interface IIdentityService
    {
        Task<(Result Result, string UserId)> CreateUserAsync(string fullName, string userName, string password);

        Task<Result> DeleteUserAsync(string userId);

        Task<UserModel> GetUserAsync(string userName);
    }
}
