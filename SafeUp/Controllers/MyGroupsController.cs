using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SafeUp.Controllers
{
    public class MyGroupsController : Controller
    {
        // GET: MyGroups
     
        public ActionResult UserGroups()
        {

            return PartialView("~/Views/Partials/LoggedIn/Groups/MyGroupsPartial.cshtml");
        }


    }
}