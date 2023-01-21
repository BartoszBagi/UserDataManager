using MediatR;
using UserDataManager.Server.DbContextConfiguration;
using UserDataManager.Server.Models;
using UserDataManager.Shared.User.Models;

namespace UserDataManager.Server.UsersHandlers.Commands.EditUserCommands
{
    public class EditUserCommandHandler : IRequestHandler<EditUserCommand, Unit>
    {
        private readonly UserDataManagerDbContext _context;

        public EditUserCommandHandler(UserDataManagerDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
            var userToEdit = await _context.FindAsync<User>(request.UserVm.Id);
            
            MapUserVmToUser(ref userToEdit, request.UserVm);
            await _context.SaveChangesAsync();

            return new Unit();
        }

        private void MapUserVmToUser(ref User userToEdit, UserVm userVm)
        {
            var userAtributes = _context.Attributes.Where(a => a.UserId == userVm.Id).ToList();
            userToEdit.Name = userVm.Name;
            userToEdit.LastName = userVm.LastName;
            userToEdit.BirthDate = userVm.BirthDate;
            userToEdit.Gender = userVm.Gender;
            
            foreach (var atr in userVm.Attributes)
            {
                if (userAtributes.Count() > 0) 
                {
                    var test = userAtributes.Contains(new UserAttribute() { Name = atr.Name, Value = atr.Value});

                    var isAttributeExists = userAtributes.FirstOrDefault(a => a.Name == atr.Name && a.Value == atr.Value);
                    if(isAttributeExists == null)
                    {
                        var attributeToAdd = new UserAttribute() { Name = atr.Name, Value = atr.Value, UserId = userToEdit.Id };
                        userToEdit.Attributes.Add(attributeToAdd);
                    }
                }               
            }
        }
    }
}
