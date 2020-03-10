using AutoMapper;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Task_1.Entities;
using Task_1.PL.WEB_UI.Models.Recipie;

namespace Task_1.PL.WEB_UI.ApiControllers
{
    [RoutePrefix("api/recipies")]
    public class RecipiesController : ApiController
    {
        private IRecipieLogic recipieLogic;
        private IImageLogic imageLogic;

        public RecipiesController(IRecipieLogic recipieLogic, IImageLogic imageLogic)
        {
            this.recipieLogic = recipieLogic;
            this.imageLogic = imageLogic;
        }

        [Route(@"{id}")]
        public IHttpActionResult Get(int id)
        {
            RecipieDTO recipie = recipieLogic.Get(id);
            if (recipie == null)
            {
                return NotFound();
            }

            return Ok(recipie);
        }

        [Route(@"{query:regex(^[A-Za-z][-_A-Za-z0-9 ]*)?}")]
        public IHttpActionResult Get([FromUri]string query = null)
        {
            if (String.IsNullOrWhiteSpace(query))
            {
                return Ok(recipieLogic.GetAll());
            }
            else if (query.Length == 1)
            {
                return Ok(recipieLogic.GetAllByLetter(query[0]));
            }
            else
            {
                var recipie = recipieLogic.GetByString(query);
                if (recipie != null)
                {
                    return Ok(recipie);
                }
                else
                {
                    return Ok(recipieLogic.GetAllByString(query));
                }
            }
        }

        [Route("")]
        public IHttpActionResult Post([FromBody]CreateRecipieVM recipie)
        {
            RecipieVM newRecipie = Mapper.Map<CreateRecipieVM, RecipieVM>(recipie);
            newRecipie.Image_id = 48; //TODO: дефолтная картинка для аварда ибо РЕСТ, 48 ибо больше 0 надо
            if (newRecipie.Description == null)
            {
                newRecipie.Description = "";
            }
            if (ModelState.IsValid)
            {
                newRecipie.Id = recipieLogic.Create(Mapper.Map<RecipieVM, RecipieDTO>(newRecipie));
                if (newRecipie.Id >= 0)
                {
                    return Created($"api/recipies/{newRecipie.Id}", newRecipie);
                }
            }
            return BadRequest();
        }

        [Route("{id}")]
        public IHttpActionResult Put([FromUri]int id, [FromBody]RecipieVM recipie)
        {
            if (ModelState.IsValid && recipieLogic.Update(Mapper.Map<RecipieVM, RecipieDTO>(recipie)))
            {
                return Ok();
            }

            return BadRequest();
        }

        [Route("{id}")]
        public IHttpActionResult Delete([FromUri]int id)
        {
            if (recipieLogic.Delete(id))
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
