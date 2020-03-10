using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_1.Entities;

namespace Task_1.DAL.Abstract
{
    public interface IImageDAL
    {
        int Create(ImageDTO img);

        ImageDTO Get(int id);

        List<ImageDTO> GetAll();

        bool Update(ImageDTO img);

        bool Delete(int id);
    }
}
