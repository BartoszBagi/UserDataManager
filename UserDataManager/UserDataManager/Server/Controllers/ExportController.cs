using Microsoft.AspNetCore.Mvc;
using UserDataManager.Server.ExportService.ExportQueries;
using UserDataManager.Server.UsersHandlers.Queries.AllUsersQueries;
using UserDataManager.Shared.User.Models;

namespace UserDataManager.Server.Controllers
{
    [ApiController]
    [Route("api/export")]
    public class ExportController : ApiControllerBase
    {
        public ExportController()
        {
        }

        [HttpGet]
        [Route("{jsonString}")]
        public async Task<byte[]> GetFileAsync(string jsonString)
        {
            var result = await Mediator.Send(new ExportQuery() { UsersDataAsJson = jsonString });
            return result;
        }
    }
}

