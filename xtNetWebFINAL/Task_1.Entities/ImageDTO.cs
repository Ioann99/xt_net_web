using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1.Entities
{
    public class ImageDTO
    {
        public ImageDTO()
        {   
            
        }

        public ImageDTO(int Id)

        {
            this.Id = Id;
        }

        public int Id { get; set; }

        public byte[] Data { get; set; }

        public string Type { get; set; }
    }
}
