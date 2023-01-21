using System.ComponentModel.DataAnnotations.Schema;
using UserDataManager.Shared.User.Models;

namespace UserDataManager.Server.Models
{
    internal class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        [Column(TypeName = "Date")]
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public List<UserAttribute> Attributes { get; set; } = new List<UserAttribute>();


        public UserVm MapUserToVm(User user, List<UserAttribute> attributes)
        {
            var attributesToAdd = new List<UserAttributeVm>();
            if (attributes.Count() > 0)
            {
                foreach (var attribute in attributes)
                {
                    var attributeVm = new UserAttributeVm() { Name = attribute.Name, Value = attribute.Value };
                    attributesToAdd.Add(attributeVm);
                }
            }

            var userVm = new UserVm()
            {
                Id = user.Id,
                Name = user.Name,
                LastName = user.LastName,
                BirthDate = user.BirthDate,
                Gender = user.Gender,
                Attributes = attributesToAdd
            };

            return userVm;
        }
    }
    
}
