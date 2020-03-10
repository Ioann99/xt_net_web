using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Task_1.PL.WEB_UI.Controllers
{
    public class ValidationController : Controller
    {
        private IUserLogic userLogic;
        private IRecipieLogic recipieLogic;

        public ValidationController(IUserLogic userLogic, IRecipieLogic recipieLogic)
        {
            this.userLogic = userLogic;
            this.recipieLogic = recipieLogic;
        }

        public JsonResult IsUserNameAllowed(string name)
        {
            return Json(!userLogic.GetAll().Any(u => string.Equals(u.Name, name, StringComparison.InvariantCultureIgnoreCase)), JsonRequestBehavior.AllowGet);
        }

        public JsonResult IsRecipieTitleAllowed(string title)
        {
            return Json(!recipieLogic.GetAll().Any(u => string.Equals(u.Title, title, StringComparison.InvariantCultureIgnoreCase)), JsonRequestBehavior.AllowGet);
        }
        
    }
}