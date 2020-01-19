using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PoseidonTradeDddApi.Application.Users.Commands.CreateUserItem;
using PoseidonTradeDddApi.Application.Users.Commands.DeleteUserItem;
using PoseidonTradeDddApi.Application.Users.Commands.UpdateUserItem;
using PoseidonTradeDddApi.Application.Users.Queries.GetAllUsers;
using PoseidonTradeDddApi.Application.Users.Queries.GetUser;
using PoseidonTradeDddApi.Domain.Constants;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoseidonTradeDddApi.Api.Controllers
{
    [Authorize]
    public class UserController : ApiController
    {
        /// <summary>
        /// Retrieve the user by userName.
        /// </summary>
        /// <param name="userName">The UserName.</param>
        /// <returns></returns>
        [HttpGet("{userName}")]
        public async Task<ActionResult<UserModel>> Get(string userName)
        {
            var userModel = await Mediator.Send(new GetUserQuery { UserName = userName });

            if (userModel == null)
            {
                return new NotFoundResult();
            }

            return userModel;
        }

        /// <summary>
        /// Retrieve all users.
        /// </summary>
        /// <returns>All UserModels.</returns>
        [Authorize(Policy = RoleNames.Admin)]
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<List<UserModel>>> GetAll()
        {
            return (await Mediator.Send(new GetAllUsersQuery())).ToList();
        }

        /// <summary>
        /// Create a new user item.
        /// </summary>
        /// <param name="command">CreateUserItemCommand to create the bid item</param>
        /// <returns>Number of items added.</returns>
        [Authorize(Policy = RoleNames.Admin)]
        [HttpPost]
        public async Task<ActionResult<string>> Create(CreateUserItemCommand command)
        {
            return await Mediator.Send(command);
        }

        /// <summary>
        /// Update an existing user item.
        /// </summary>
        /// <param name="id">id of the user item to update</param>
        /// <param name="command">UpdateUserItemCommand to update the user item</param>
        /// <returns></returns>
        [Authorize(Policy = RoleNames.Admin)]
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(string id, UpdateUserItemCommand command)
        {
            if (id != command.UserId)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        /// <summary>
        /// Deletes an existing user item.
        /// </summary>
        /// <param name="id">id of the user item to delete</param>
        /// <returns></returns>
        [Authorize(Policy = RoleNames.Admin)]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            await Mediator.Send(new DeleteUserItemCommand { UserId = id });

            return NoContent();
        }
    }
}
