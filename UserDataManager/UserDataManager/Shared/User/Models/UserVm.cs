using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDataManager.Shared.User.Models.ModelsValidation;

namespace UserDataManager.Shared.User.Models
{
    public class UserVm
    {        
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z\s.\-']{3,50}$", ErrorMessage = "User name contains invalid characters.")]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z\s.\-']{3,150}$", ErrorMessage = "User name contains invalid characters.")]
        public string LastName { get; set; }

        [Required]
        [DateOfBirthRange(ErrorMessage = "BirthDate must be between {1:M/d/yyyy} and {2:M/d/yyyy}")]
        public DateTime BirthDate { get; set; } = DateTime.Now;

        [Required]
        public string Gender { get; set; }
        public List<UserAttributeVm> Attributes { get; set; } = new List<UserAttributeVm>();
    }

}
