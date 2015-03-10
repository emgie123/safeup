using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace SafeUp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View("Index");
        }

        public ActionResult LoggedIn()
        {
            ViewBag.UserName = "Kasia Kowalska";
            return View("LoggedInView");
        }

        public ActionResult UserProfile()
        {

            return PartialView("~/Views/Partials/UserProfilePartialView.cshtml");
        }


        public ActionResult UserGroups()
        {

            return PartialView("~/Views/Partials/UserGroupsPartialView.cshtml");
        }

        public ActionResult UserStats()
        {

            return PartialView("~/Views/Partials/UserStatsPartialView.cshtml");
        }

 
    }
}