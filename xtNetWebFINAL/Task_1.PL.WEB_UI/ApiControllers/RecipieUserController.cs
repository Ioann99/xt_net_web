using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Task_1.PL.WEB_UI.ApiControllers
{
    [RoutePrefix("api/recipie-user")]
    public class RecipieUserController : ApiController
    {
        private IUserLogic userLogic;

        public RecipieUserController(IUserLogic userLogic)
        {
            this.userLogic = userLogic;
        }

        [Route(@"{userId_recipieId:regex(^\d{1,3}_\d{1,3}$)}")]
        public IHttpActionResult Post([FromUri]string userId_recipieId)
        {
            string userId = userId_recipieId.Split('_')[0];
            string recipieId = userId_recipieId.Split('_')[1];
            int user_id;
            int recipie_id;
            bool uIdOk = int.TryParse(userId, out user_id);
            bool aIdOk = int.TryParse(recipieId, out recipie_id);
            if (uIdOk && aIdOk && (userLogic.AddRecipie(user_id, recipie_id)))
            {
                return Ok();
            }
            else
            {
                return Json(new { uIdOk, recipie_id, addSuccsess = false });
            }
        }
    }
}
