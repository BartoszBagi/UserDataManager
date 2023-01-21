using MediatR;
using UserDataManager.Shared.User.Models;

namespace UserDataManager.Server.UsersHandlers.Queries.GetUserQuery
{
    public class GetUserQuery : IRequest<UserVm>
    {
        public int Id { get; set; }
    }
}
