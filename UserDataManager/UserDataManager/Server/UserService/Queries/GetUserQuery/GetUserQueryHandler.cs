using MediatR;
using UserDataManager.Server.DbContextConfiguration;
using UserDataManager.Server.Models;
using UserDataManager.Shared.User.Models;

namespace UserDataManager.Server.UsersHandlers.Queries.GetUserQuery
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserVm>
    {
        private readonly UserDataManagerDbContext _context;

        public GetUserQueryHandler(UserDataManagerDbContext context)
        {
            _context = context;
        }
        public async Task<UserVm> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FindAsync(request.Id);
            var userAttributes = _context.Attributes.Where(a => a.UserId == request.Id).ToList();
            if (userAttributes == null)
                userAttributes = new List<UserAttribute>();
            var userVm = new UserVm();

            if(user != null)
            {
                userVm = user.MapUserToVm(user, user.Attributes);             
            }

            return userVm;
        }
    }
}
