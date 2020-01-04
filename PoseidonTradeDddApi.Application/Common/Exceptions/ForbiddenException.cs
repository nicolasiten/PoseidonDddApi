using System;
using System.Collections.Generic;
using System.Text;

namespace PoseidonTradeDddApi.Application.Common.Exceptions
{
    public class ForbiddenException : Exception
    {
        public ForbiddenException()
            : base("Claim missing to execute action.")
        {
        }
    }
}
