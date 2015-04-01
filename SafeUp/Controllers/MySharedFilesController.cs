using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SafeUp.Controllers
{
    public class MySharedFilesController : Controller
    {

        public ActionResult UserSharedFiles()
        {

            return PartialView("~/Views/Partials/LoggedIn/SharedFiles/MySharedFilesPartial.cshtml");
        }

    }
}