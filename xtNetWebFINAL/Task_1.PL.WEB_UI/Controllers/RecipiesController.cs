using AutoMapper;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task_1.Entities;
using Task_1.PL.WEB_UI.Models.Recipie;
using Task_1.PL.WEB_UI.Models.File;

namespace Task_1.PL.WEB_UI.Controllers
{
    public class RecipiesController : Controller
    {
        private IRecipieLogic recipieLogic;
        private IImageLogic imageLogic;

        public RecipiesController(IRecipieLogic recipiedLogic, IImageLogic imageLogic)
        {
            this.recipieLogic = recipiedLogic;
            this.imageLogic = imageLogic;
        }

        // GET: Recipies
        public ActionResult Index(string query)
        {
            List<RecipieVM> model = null;
            if (String.IsNullOrWhiteSpace(query))
            {
                model = Mapper.Map<List<RecipieVM>>(recipieLogic.GetAll());
                return View(model);
            }
            else if (query.Length == 1)
            {
                model = Mapper.Map<List<RecipieVM>>(recipieLogic.GetAllByLetter(query[0]));
                return View(model);
            }
            else
            {
                model = Mapper.Map<List<RecipieVM>>(recipieLogic.GetAllByString(query));
                return View(model);
            }
        }

        // GET: Recipie/Details/5
        public ActionResult Details(string id)
        {
            int number;
            RecipieVM recipie;
            if (int.TryParse(id, out number))
            {
                recipie = Mapper.Map<RecipieDTO, RecipieVM>(recipieLogic.Get(number));
            }
            else
            {
                recipie = Mapper.Map<RecipieVM>(recipieLogic.GetByString(id));
            }

            if (Request.IsAjaxRequest())
            {
                return PartialView("_modalRecipie", recipie);
            }
            return View(recipie);
        }

        // GET: Recipiess/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Recipies/Create
        [HttpPost]
        public ActionResult Create(CreateRecipieVM recipie, HttpPostedFileBase image)
        {
            try
            {
                RecipieVM newRecipie = Mapper.Map<CreateRecipieVM, RecipieVM>(recipie);
                if (image == null)
                {
                    newRecipie.Image_id = 0;
                }
                else
                {
                    byte[] data = new byte[image.ContentLength];
                    image.InputStream.Read(data, 0, data.Length);
                    FileInfo newFIle = new FileInfo()
                    {
                        Data = data,
                        Type = image.ContentType,
                        Name = image.FileName
                    };

                    int imageID = imageLogic.CreateNew(Mapper.Map<FileInfo, ImageDTO>(newFIle));

                    newRecipie.Image_id = imageID;
                }
                if (newRecipie.Description == null)
                {
                    newRecipie.Description = "";
                }

                if (ModelState.IsValid && newRecipie.Image_id != 0 && (recipieLogic.Create(Mapper.Map<RecipieVM, RecipieDTO>(newRecipie)) >= 0))
                {
                    return RedirectToAction("Index");
                }

                return View(recipie);
            }
            catch
            {
                return View(recipie);
            }
        }

        // GET: Recipies/Edit/5
        public ActionResult Edit(int id)
        {
            var model = Mapper.Map<RecipieDTO, RecipieVM>(recipieLogic.Get(id));
            return View(model);
        }

        // POST: Recipies/Edit/5
        [HttpPost]
        public ActionResult Edit(RecipieVM recipie, HttpPostedFileBase image)
        {
            try
            {
                if (image != null && image.ContentLength != 0)
                {
                    byte[] data = new byte[image.ContentLength];
                    image.InputStream.Read(data, 0, data.Length);
                    FileInfo newFIle = new FileInfo()
                    {
                        Data = data,
                        Type = image.ContentType,
                        Name = image.FileName
                    };
                    ImageDTO oldImage = Mapper.Map<FileInfo, ImageDTO>(newFIle);
                    oldImage.Id = recipie.Image_id;
                    imageLogic.Update(oldImage);
                }

                if (ModelState.IsValid && recipieLogic.Update(Mapper.Map<RecipieVM, RecipieDTO>(recipie)))
                {
                    return RedirectToAction("Index");
                }
                return View(recipie);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET: User/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var recipie = Mapper.Map<RecipieVM>(recipieLogic.Get(id));
            return View(recipie);
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(RecipieVM recipie)
        {
            try
            {
                if (recipieLogic.Delete(recipie.Id))
                {
                    return RedirectToAction("Index");
                }
                return HttpNotFound();
            }
            catch
            {
                return RedirectToAction("Index");
                throw;
            }
        }

    }
}
