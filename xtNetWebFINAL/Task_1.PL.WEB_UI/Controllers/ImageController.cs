using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task_1.Entities;

namespace Task_1.PL.WEB_UI.Controllers
{
    public class ImageController : Controller
    {
        private IImageLogic imageLogic;

        public ImageController(IImageLogic imageLogic)
        {
            this.imageLogic = imageLogic;
        }

        public ActionResult Index()
        {
            var model = imageLogic.GetAll().Select(img => img.Id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase image)
        {
            if (image == null && image.ContentLength == 0)
            {
                return RedirectToAction("Index");
            }
            byte[] data = new byte[image.ContentLength];
            image.InputStream.Read(data, 0, data.Length);
            imageLogic.CreateNew(new ImageDTO()
            {
                Data = data,
                Type = image.ContentType
            });
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Get(int id)
        {
            ImageDTO image = imageLogic.Get(id);
            if (image == null)
            {
                return HttpNotFound();
            }

            return File(image.Data, image.Type);
        }
    }
}