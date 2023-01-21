using MediatR;
using UserDataManager.Server.DbContextConfiguration;
using UserDataManager.Shared.User.Models;
using UserDataManager.Server.Models;

namespace UserDataManager.Server.UsersHandlers.Queries.AllUsersQueries
{
    public class AllUsersQueryHandler : IRequestHandler<AllUsersQuery, List<UserVm>>
    {
        private readonly UserDataManagerDbContext _context;

        public AllUsersQueryHandler(UserDataManagerDbContext context)
        {
            _context = context;
        }
        public Task<List<UserVm>> Handle(AllUsersQuery request, CancellationToken cancellationToken)
        {
            var resultUsers = new List<UserVm>();

            if (_context.Users.Count() > 0)
            {
                var allUsers = _context.Users.ToList();

                foreach (var user in allUsers)
                {
                    var userAttributes = _context.Attributes.Where(u => u.UserId == user.Id).ToList();
                    var userToAdd = user.MapUserToVm(user, userAttributes);

                    resultUsers.Add(userToAdd);
                }
            }

            return Task.FromResult(resultUsers);

        }
    }
}
