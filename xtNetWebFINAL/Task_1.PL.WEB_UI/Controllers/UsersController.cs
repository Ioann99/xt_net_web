using AutoMapper;
using BLL;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Task_1.Entities;
using Task_1.PL.WEB_UI.Models.Recipie;
using Task_1.PL.WEB_UI.Models.File;
using Task_1.PL.WEB_UI.Models.User;

namespace Task_1.PL.WEB_UI.Controllers
{
    public class UsersController : Controller
    {
        private IUserLogic userLogic;
        private IRecipieLogic recipieLogic;
        private IImageLogic imageLogic;

        public UsersController(IUserLogic userLogic, IRecipieLogic recipieLogic, IImageLogic imageLogic)
        {
            this.userLogic = userLogic;
            this.recipieLogic = recipieLogic;
            this.imageLogic = imageLogic;
        }

        // GET: User
        public ActionResult Index(string query)
        {
            List<UserVM> model;
            if (String.IsNullOrWhiteSpace(query))

            {
                model = Mapper.Map<List<UserVM>>(userLogic.GetAll());
            }

            else if (query.Length == 1)
            {
                model = Mapper.Map<List<UserVM>>(userLogic.GetAllByLetter(query[0]));
            }

            else
            {
                model = Mapper.Map<List<UserVM>>(userLogic.GetAllByString(query));
            }

            foreach (var user in model)
            {
                user.Recipies = Mapper.Map<List<RecipieVM>>(recipieLogic.GetAllByUser(user.Id));
            }

            return View(model);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(CreateUserVM user, HttpPostedFileBase image)
        {
            if (image == null)
            {
                user.Image_id = 0;
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

                user.Image_id = imageLogic.Create(user.Image_id, Mapper.Map<FileInfo, ImageDTO>(newFIle));
            }

            if (ModelState.IsValid && (userLogic.Create(Mapper.Map<CreateUserVM, UserDTO>(user)) >= 0))
            {
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            var user = Mapper.Map<UserDTO, EditUserVM>(userLogic.Get(id));
            user.Recipie = Mapper.Map<List<RecipieDTO>, List<SelectListItem>>(recipieLogic.GetAllByUser(user.Id));
            user.Recipie.Add(new SelectListItem() { Text = "No Action", Value = "0" });
            user.MissingRecipies = Mapper.Map<List<RecipieDTO>, List<SelectListItem>>(recipieLogic.GetMissingRecipies(user.Id));
            user.MissingRecipies.Add(new SelectListItem() { Text = "No Action", Value = "0" });
            return View(user);
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(EditUserVM user, HttpPostedFileBase image)
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

                user.Image_id = imageLogic.Create(user.Image_id, Mapper.Map<FileInfo, ImageDTO>(newFIle));
            }
            if (user.SelectedRecipie > 0)
            {
                userLogic.AddRecipie(user.Id, user.SelectedRecipie);
            }

            if (user.SelectedRecipieToDelete > 0)
            {
                userLogic.RemoveRecipie(user.Id, user.SelectedRecipieToDelete);
            }

            if (ModelState.IsValid && userLogic.Update(Mapper.Map<EditUserVM, UserDTO>(user)))
            {
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: User/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var user = Mapper.Map<UserVM>(userLogic.Get(id));
            user.Recipies = Mapper.Map<List<RecipieVM>>(recipieLogic.GetAllByUser(user.Id));
            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(UserVM user)
        {
            try
            {
                if (userLogic.Delete(user.Id))
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

        public ActionResult UsersList()
        {
            var users = Mapper.Map<List<UserVM>>(userLogic.GetAll());
            foreach (var user in users)
            {
                user.Recipies = Mapper.Map<List<RecipieVM>>(recipieLogic.GetAllByUser(user.Id));
            }

            System.Text.StringBuilder str = new System.Text.StringBuilder();
            foreach (var user in users)
            {
                str.Append($"{ user.Id}. { user.Name}, {user.Age} years. ");
                if (user.Recipies != null)
                {
                    str.Append("Recipies:");
                    foreach (var recipie in user.Recipies)
                    {
                        str.Append($" {recipie.Title} |");
                    }
                }

                else
                {
                    str.Append("No Recipies\n");
                }

                str.AppendLine();
            }

            return File(Encoding.UTF8.GetBytes(str.ToString()), "plain/text", "Users List.txt");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var user = Mapper.Map<UserDTO, UserVM>(userLogic.Get(id));
            user.Recipies = Mapper.Map<List<RecipieDTO>, List<RecipieVM>>(recipieLogic.GetAllByUser(user.Id));
            return View(user);
        }

        [HttpGet]
        public ActionResult RecipieUserByUrl(string userId_recipieId)
        {
            string[] arr = userId_recipieId.Split('_');
            string userId = arr[0];
            string recipieId = arr[1];
            int user_id;
            int recipie_id;

            if (int.TryParse(userId, out user_id) &&
                int.TryParse(recipieId, out recipie_id))
            {
                if (userLogic.AddRecipie(user_id, recipie_id))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "User have recipie yet or incorrect user and recipie id");
                }
            }

            return RedirectToAction("Index");
        }

    }
}
