using System;
using System.Collections.Generic;
using System.Text;

namespace PoseidonTradeDddApi.Application.Users.Queries.GetUser
{
    public class UserModel
    {
        public string UserId { get; set; }

        public string FullName { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public IEnumerable<string> RoleClaims { get; set; }
    }
}
