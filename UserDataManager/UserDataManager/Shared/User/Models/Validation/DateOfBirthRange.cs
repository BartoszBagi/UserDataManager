using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserDataManager.Shared.User.Models.ModelsValidation
{
    public class DateOfBirthRange : RangeAttribute
    {
        public DateOfBirthRange()
            : base(typeof(DateTime), DateTime.Now.AddYears(-150).ToShortDateString(), DateTime.Now.ToShortDateString()) { }
    }
}
