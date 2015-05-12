using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SafeUp.Models.ActionFilters;

namespace SafeUp.Controllers
{
    public class MySharedFilesController : Controller
    {
        [CustomSessionAuthorizeFilter]
        public ActionResult UserSharedFiles()
        {

            return PartialView("~/Views/Partials/LoggedIn/SharedFiles/MySharedFilesPartial.cshtml");
        }

    }
}