using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Task_1.Entities;
using RemoteAttribute = System.Web.Mvc;

namespace Task_1.PL.WEB_UI.Models.User
{
    public class CreateUserVM : IValidatableObject
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        [RegularExpression(@"[-A-Za-zА-Яа-яЁё0-9 _]*", ErrorMessage = "Strats with letter, allowed only letters, numbers and underline")]
        [System.Web.Mvc.Remote("IsUserNameAllowed", "Validation")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime Birthdate { get; set; }

        public int Image_id { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var age = ((DateTime.Now - this.Birthdate).TotalDays / 365.25);
            if (age <= 150 && age >= 0)
            {
                yield break;
            }
            else
            {
                yield return new ValidationResult("Age should be 0-150 years", new[] { nameof(Birthdate) });
            }
        }
    }
}