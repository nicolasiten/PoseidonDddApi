using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PoseidonTradeDddApi.Application.Users.Queries.GetAllUsers;
using PoseidonTradeDddApi.Application.Users.Queries.GetUser;
using PoseidonTradeDddApi.Domain.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoseidonTradeDddApi.Api.Controllers
{
    [Authorize]
    public class UserController : ApiController
    {
        [HttpGet("{action}")]
        public async Task<ActionResult<UserModel>> Get(GetUserQuery query)
        {
            var userModel = await Mediator.Send(query);

            if (userModel == null)
            {
                return new NotFoundResult();
            }

            return userModel;
        }

        [Authorize(Policy = RoleNames.Admin)]
        [HttpGet("{action}")]
        public async Task<ActionResult<List<UserModel>>> GetAll()
        {
            return (await Mediator.Send(new GetAllUsersQuery())).ToList();
        }

        //[Authorize(Policy = RoleNames.Admin)]
        //[HttpPost]
        //public async Task<ActionResult<int>> Create()
        //{
        //}

        //[Authorize(Policy = RoleNames.Admin)]
        //[HttpPut("{id}")]
        //public async Task<ActionResult> Update()
        //{

        //}

        //[Authorize(Policy = RoleNames.Admin)]
        //[HttpDelete("{id}")]
        //public async Task<ActionResult> Delete(int id)
        //{

        //}
    }
}
