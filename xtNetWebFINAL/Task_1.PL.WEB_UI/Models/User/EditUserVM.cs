using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task_1.PL.WEB_UI.Models.Recipie;

namespace Task_1.PL.WEB_UI.Models.User
{
    public class EditUserVM : IValidatableObject
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        [RegularExpression(@"^[A-Za-zа-яА-ЯеЁ][-A-Za-zА-Яа-яЁё0-9 _]*", ErrorMessage = "Strats with letter, allowed only letters, numbers and underline")]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Birthdate { get; set; }

        public int Image_id { get; set; }

        public bool HasImage { get; set; }

        public List<SelectListItem> Recipie { get; set; }

        public List<SelectListItem> MissingRecipies { get; set; }

        [Display(Name = "Write new recepie")]
        public int SelectedRecipie { get; set; }

        [Display(Name = "Remove User's recipie")]
        public int SelectedRecipieToDelete { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var age = (int)((DateTime.Now - this.Birthdate).TotalDays / 365.25);
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