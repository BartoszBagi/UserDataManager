using MediatR;
using UserDataManager.Shared.User.Models;

namespace UserDataManager.Server.UsersHandlers.Queries.AllUsersQueries
{
    public class AllUsersQuery : IRequest<List<UserVm>>
    {
    }
}
