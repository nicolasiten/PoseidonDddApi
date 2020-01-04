using System;
using System.Collections.Generic;
using System.Text;

namespace PoseidonTradeDddApi.Application.Common.Interfaces
{
    public interface ICurrentUserService
    {
        string UserName { get; }

        IEnumerable<string> RoleClaims { get; }
    }
}
