using MediatR;
using UserDataManager.Server.DbContextConfiguration;
using UserDataManager.Server.Models;

namespace UserDataManager.Server.UsersHandlers.Commands.AddUserCommands
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, Unit>
    {
        private readonly UserDataManagerDbContext _context;

        public AddUserCommandHandler(UserDataManagerDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var newAttributes = new List<UserAttribute>();

            if (request.UserToAdd.Attributes.Count() > 0)
            {
                foreach (var attribute in request.UserToAdd.Attributes)
                {
                    var newAttribute = new UserAttribute()
                    {

                        Name = attribute.Name,
                        Value = attribute.Value
                    };
                    newAttributes.Add(newAttribute);
                }
            }
            var newUser = new User()
            {
                Name = request.UserToAdd.Name,
                LastName = request.UserToAdd.LastName,
                BirthDate = request.UserToAdd.BirthDate,
                Gender = request.UserToAdd.Gender,
                Attributes = newAttributes
            };
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();


            

            

            return Unit.Value;
        }
    }
}
