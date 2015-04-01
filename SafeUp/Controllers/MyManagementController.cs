using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SafeUp.Controllers
{
    public class MyManagementController : Controller
    {

        public ActionResult UserManagement()
        {

            return PartialView("~/Views/Partials/LoggedIn/Management/MyGroupsManagementPartial.cshtml");
        }
    }
}