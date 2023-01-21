using MediatR;

namespace UserDataManager.Server.UsersHandlers.Commands.DeleteUserCommands
{
    public class DeleteUserCommand : IRequest<Unit>
    {
        public int UserToDeleteId { get; set; }
    }
}
