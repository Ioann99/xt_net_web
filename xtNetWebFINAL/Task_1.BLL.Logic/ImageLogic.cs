using BLL;
using DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_1.DAL.Abstract;
using Task_1.Entities;

namespace Task_1.BLL.Logic
{
    public class ImageLogic : IImageLogic
    {

        private IImageDAL imageDAL;

        public ImageLogic(IImageDAL imageDAL)
        {
            if (imageDAL == null)
            {
                throw new ArgumentException("Null pointer in BLL constructir");
            }
            else
            {
                this.imageDAL = imageDAL;
            }
        }

        public int Create(int oldImageId, ImageDTO img)
        {
            if (oldImageId != 0)
            {
                imageDAL.Delete(oldImageId);
                return imageDAL.Create(img);
            }
            return imageDAL.Create(img);
        }

        public int CreateNew(ImageDTO img)
        {
            return imageDAL.Create(img);
        }

        public bool Delete(int id)
        {
            return imageDAL.Delete(id);
        }

        public ImageDTO Get(int id)
        {
            return imageDAL.Get(id);
        }

        public List<ImageDTO> GetAll()
        {
            return imageDAL.GetAll().ToList();
        }

        public bool Update(ImageDTO img)
        {
            return imageDAL.Update(img);
        }

    }

}
