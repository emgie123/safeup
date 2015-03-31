using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using SafeUp.Models.LoggedIn;

namespace SafeUp.Controllers
{
    public class LoggedInController : Controller
    {
        // GET: LoggedIn
        public ActionResult LoggedIn()
        {

            return RedirectToAction("UserFiles");
        }

        public ActionResult UserFiles()
        {
          

           return PartialView("~/Views/Partials/LoggedIn/Files/MyFilesPartial.cshtml",new User());
           
           
        }


        public ActionResult UserGroups()
        {

            return PartialView("~/Views/Partials/LoggedIn/Groups/MyGroupsPartial.cshtml");
        }

        public ActionResult SharedFiles()
        {

            return PartialView("~/Views/Partials/LoggedIn/SharedFiles/MySharedFilesPartial.cshtml");
        }

        public ActionResult Management()
        {

            return PartialView("~/Views/Partials/LoggedIn/Management/MyGroupsManagementPartial.cshtml");
        }
    }
}