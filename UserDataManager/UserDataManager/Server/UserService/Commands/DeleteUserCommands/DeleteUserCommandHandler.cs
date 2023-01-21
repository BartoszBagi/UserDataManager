using MediatR;
using UserDataManager.Server.DbContextConfiguration;

namespace UserDataManager.Server.UsersHandlers.Commands.DeleteUserCommands
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Unit>
    {
        private readonly UserDataManagerDbContext _context;

        public DeleteUserCommandHandler(UserDataManagerDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var userToDelete = _context.Users.First(u => u.Id == request.UserToDeleteId);
            if (userToDelete != null)
            {
                _context.Users.Remove(userToDelete);
                await _context.SaveChangesAsync();
            }
            return Unit.Value;
        }
    }
}
