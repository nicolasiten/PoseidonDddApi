using PoseidonTradeDddApi.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PoseidonTradeDddApi.Application.Interfaces
{
    public interface IIdentityService
    {
        Task<(Result Result, string UserId)> CreateUserAsync(string fullName, string userName, string password);

        Task<Result> DeleteUserAsync(string userId);
    }
}
