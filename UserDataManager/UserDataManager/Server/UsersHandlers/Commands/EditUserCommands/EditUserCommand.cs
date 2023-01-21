using MediatR;
using UserDataManager.Shared.User.Models;

namespace UserDataManager.Server.UsersHandlers.Commands.EditUserCommands
{
    public class EditUserCommand : IRequest<Unit>
    {
        public UserVm UserVm { get; set; }
    }
}
