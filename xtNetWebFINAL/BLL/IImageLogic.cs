using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_1.Entities;

namespace BLL
{
    public interface IImageLogic
    {
        int Create(int oldImageId, ImageDTO img);

        int CreateNew(ImageDTO img);

        List<ImageDTO> GetAll();

        ImageDTO Get(int id);

        bool Update(ImageDTO img);

        bool Delete(int id);
    }
}
