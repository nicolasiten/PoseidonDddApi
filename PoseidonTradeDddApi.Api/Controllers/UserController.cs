using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PoseidonTradeDddApi.Application.Users.Queries.GetUser;
using PoseidonTradeDddApi.Domain.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoseidonTradeDddApi.Api.Controllers
{
    [Authorize(Policy = RoleNames.Admin)]
    public class UserController : ApiController
    {
        [HttpGet]
        public async Task<ActionResult<UserModel>> Get(GetUserQuery query)
        {
            var userModel = await Mediator.Send(query);

            if (userModel == null)
            {
                return new NotFoundResult();
            }

            return userModel;
        }

        //[HttpPost]
        //public async Task<ActionResult<int>> Create()
        //{
        //}

        //[HttpPut("{id}")]
        //public async Task<ActionResult> Update()
        //{

        //}

        //[HttpDelete("{id}")]
        //public async Task<ActionResult> Delete(int id)
        //{

        //}
    }
}
