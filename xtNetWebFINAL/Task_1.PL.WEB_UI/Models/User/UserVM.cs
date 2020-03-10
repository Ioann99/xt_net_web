using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Task_1.Entities;
using Task_1.PL.WEB_UI.Models.Recipie;

namespace Task_1.PL.WEB_UI.Models.User
{
    public class UserVM
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime Birthdate { get; set; }

        public int Age { get; set; }

        [Display(Name = "Image")]
        public int Image_id { get; set; }

        [UIHint("RecipieListTempl")]
        public List<RecipieVM> Recipies { get; set; }
    }
}