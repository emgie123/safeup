using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using SafeUp.Models.LoggedIn;

namespace SafeUp.Controllers
{
    public class MyFilesController : Controller
    {
        // GET: LoggedIn
    

        public ActionResult UserFiles()
        {
           
           return PartialView("~/Views/Partials/LoggedIn/Files/MyFilesPartial.cshtml");
 
        }

        public ActionResult File()
        {
            return PartialView("~/Views/Partials/LoggedIn/Files/FileDetailsPartial.cshtml");
        }



     
    }
}