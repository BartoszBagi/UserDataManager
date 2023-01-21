using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserDataManager.Shared.User.Models;

namespace UserDataManager.Server.UsersHandlers.Commands.AddUserCommands
{
    public class AddUserCommand : IRequest<Unit>
    {
        public UserVm UserToAdd { get; set; }
    }
}
