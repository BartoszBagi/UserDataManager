using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserDataManager.Server.UsersHandlers.Commands;
using UserDataManager.Server.UsersHandlers.Commands.AddUserCommands;
using UserDataManager.Server.UsersHandlers.Commands.DeleteUserCommands;
using UserDataManager.Server.UsersHandlers.Commands.EditUserCommands;
using UserDataManager.Server.UsersHandlers.Queries.AllUsersQueries;
using UserDataManager.Server.UsersHandlers.Queries.GetUserQuery;
using UserDataManager.Shared.User.Models;

namespace UserDataManager.Server.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ApiControllerBase
    {
        public UserController()
        {

        }

        [HttpGet]
        [Route("getUsers")]
        public async Task<List<UserVm>> GetAllUsers([FromQuery] AllUsersQuery command)
        {
            var result = await Mediator.Send(command);
            return result;
        }

        [HttpGet]
        [Route("getUser/{id}")]
        public async Task<UserVm> GetUser(int id)
        {
            var result = await Mediator.Send(new GetUserQuery() {Id = id});
            return result;
        }
        

        [HttpPost]
        [Route("addUser")]
        public async Task<Unit> AddUser([FromBody] UserVm userVm)
        {
            var result = await Mediator.Send(new AddUserCommand() { UserToAdd = userVm});
            return result;
        }

        [HttpPost]
        [Route("editUser")]
        public async Task<Unit> EditUser([FromBody] UserVm userVm)
        {
            var result = await Mediator.Send(new EditUserCommand() { UserVm = userVm });
            return result;
        }
        
        [HttpDelete]
        [Route("deleteUser/{id}")]
        public async Task<Unit> DeleteUser(int id)
        {
            var result = await Mediator.Send(new DeleteUserCommand() { UserToDeleteId = id });
            return result;
        }
        
    }
}
