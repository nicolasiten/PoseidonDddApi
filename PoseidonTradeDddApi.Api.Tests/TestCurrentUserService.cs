using PoseidonTradeDddApi.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PoseidonTradeDddApi.Api.Tests
{
    public class TestCurrentUserService : ICurrentUserService
    {
        public string UserName => "00000000-0000-0000-0000-000000000000";

        public IEnumerable<string> RoleClaims => new string[0];
    }
}
