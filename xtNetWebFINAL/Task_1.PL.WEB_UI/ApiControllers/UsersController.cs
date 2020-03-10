using AutoMapper;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Task_1.Entities;
using Task_1.PL.WEB_UI.Models.User;

namespace Task_1.PL.WEB_UI.ApiControllers
{
    [RoutePrefix("api/users")]
    public class UsersController : ApiController
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

        [Route(@"{query:regex([A-Za-z]\w*)?}")]
        public IHttpActionResult Get([FromUri]string query = null)
        {
            List<UserDTO> model;
            if (String.IsNullOrWhiteSpace(query))
            {
                model = userLogic.GetAll();
            }
            else if (query.Length == 1)
            {
                model = userLogic.GetAllByLetter(query[0]);
            }
            else
            {
                model = userLogic.GetAllByString(query);
            }
            foreach (var user in model)
            {
                user.Recipies = recipieLogic.GetAllByUser(user.Id);
            }

            return Ok(model);
        }

        public IHttpActionResult Get(int id)
        {
            ApiEditUserVM user = Mapper.Map<UserDTO, ApiEditUserVM>(userLogic.Get(id));
            if (user == null)
            {
                return NotFound();
            }

            user.Recipies = recipieLogic.GetAllByUser(user.Id);
            user.MissingRecipies = recipieLogic.GetMissingRecipies(user.Id);

            return Ok(user);
        }

        // POST: api/Users
        public IHttpActionResult Put([FromUri]int id, [FromBody]ApiEditUserVM user)
        {
            bool add = false;
            bool rem = false;
            bool valid = false;
            if (user.SelectedRecipie > 0)
            {
                add = userLogic.AddRecipie(user.Id, user.SelectedRecipie);
            }
            if (user.SelectedRecipieToDelete > 0)
            {
                rem = userLogic.RemoveRecipie(user.Id, user.SelectedRecipieToDelete);
            }
            if (valid = ModelState.IsValid && userLogic.Update(Mapper.Map<ApiEditUserVM, UserDTO>(user)))
            {
                return Ok();
            }
            return BadRequest($"valid: {ModelState.IsValid}, add: {add}, rem: {rem}");
        }

        [Route("")]
        public IHttpActionResult Post([FromBody]CreateUserVM user)
        {
            if (ModelState.IsValid)
            {
                int userID = userLogic.Create(Mapper.Map<CreateUserVM, UserDTO>(user));
                if (userID >= 0)
                {
                    return Created($"api/users/{userID}", user);
                }
            }
            return BadRequest();
        }

        public IHttpActionResult Delete([FromUri]int id)
        {
            if (userLogic.Delete(id))
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
