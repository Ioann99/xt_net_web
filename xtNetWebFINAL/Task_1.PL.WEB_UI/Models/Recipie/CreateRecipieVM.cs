using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Task_1.PL.WEB_UI.Models.Recipie
{
    public class CreateRecipieVM/* : IValidatableObject*/
    {
        [Required]
        [StringLength(50)]
        [RegularExpression(@"^[A-Za-z][-_A-Za-z0-9 ]*", ErrorMessage = "Strats with letter, allowed only letters, numbers and underline")]
        [System.Web.Mvc.Remote("IsRecipieTitleAllowed", "Validation")]
        public string Title { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

    }
}