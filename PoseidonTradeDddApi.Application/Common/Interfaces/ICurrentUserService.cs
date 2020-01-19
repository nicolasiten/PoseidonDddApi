using System.Collections.Generic;

namespace PoseidonTradeDddApi.Application.Common.Interfaces
{
    public interface ICurrentUserService
    {
        string UserName { get; }

        IEnumerable<string> RoleClaims { get; }
    }
}
