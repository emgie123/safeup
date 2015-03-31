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

            return View("~/Views/LoggedIn/LoggedInView.cshtml");
        }

        public ActionResult UserFiles()
        {
           return PartialView("~/Views/Partials/LoggedIn/Files/MyFilesPartial.cshtml",new User());
 
        }

        public ActionResult File(string CurrentName, DateTime CurrentDateTime, string CurrentOwner)
        {
            return PartialView("~/Views/Partials/LoggedIn/Files/FilePartial.cshtml",new File(CurrentName,CurrentDateTime,CurrentOwner));
        }


        public ActionResult UserGroups()
        {

            return PartialView("~/Views/Partials/LoggedIn/Groups/MyGroupsPartial.cshtml");
        }

        public ActionResult UserSharedFiles()
        {

            return PartialView("~/Views/Partials/LoggedIn/SharedFiles/MySharedFilesPartial.cshtml",new User());
        }

        public ActionResult UserManagement()
        {

            return PartialView("~/Views/Partials/LoggedIn/Management/MyGroupsManagementPartial.cshtml", new User());
        }
        public ActionResult Group(string CurrentName, DateTime CurrentDateTime, string CurrentOwner)
        {
            return PartialView("~/Views/Partials/LoggedIn/Management/GroupManagementPartial.cshtml", new Group(CurrentName, CurrentDateTime, CurrentOwner));
        }
    }
}