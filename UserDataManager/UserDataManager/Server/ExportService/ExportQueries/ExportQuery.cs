using MediatR;
using UserDataManager.Shared.User.Models;

namespace UserDataManager.Server.ExportService.ExportQueries
{
    public class ExportQuery : IRequest<byte[]>
    {
        public string UsersDataAsJson { get; set; }
    }
}
