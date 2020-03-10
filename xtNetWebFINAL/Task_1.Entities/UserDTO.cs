using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1.Entities
{
    public class UserDTO
    {
        public UserDTO()
        {
            this.Recipies = new List<RecipieDTO>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Birthdate { get; set; }

        public int Image_id { get; set; }

        public int Age
        {
            get
            {
                return (DateTime.MinValue + (DateTime.Now - this.Birthdate)).Year;
            }
        }

        public List<RecipieDTO> Recipies { get; set; }
    }
}
