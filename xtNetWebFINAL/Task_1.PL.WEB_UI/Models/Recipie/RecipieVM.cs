using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Task_1.Entities;

namespace Task_1.PL.WEB_UI.Models.Recipie
{
    public class RecipieVM
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [RegularExpression(@"^[A-Za-z][-_A-Za-z0-9 ]*", ErrorMessage = "Strats with letter, allowed only letters, numbers and underline")]
        public string Title { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Need a pic")]
        [Display(Name = "Image")]
        public int Image_id { get; set; }
    }
}