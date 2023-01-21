using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserDataManager.Shared.User.Models
{
    public class UserAttributeVm
    {
        [RegularExpression(@"^[\w.\-]{3,18}$", ErrorMessage = "Invalid username.")]
        public string Name { get; set; }
        [RegularExpression(@"^[\w.\-]{3,18}$", ErrorMessage = "Invalid username.")]
        public string Value { get; set; }

        public override string ToString()
        {
            return $"{Name}: {Value}";
        }

    }
}
