using System;
using System.Collections.Generic;
using System.Linq;
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
            ViewBag.UserName = "Jan Kowalski";
            return View("LoggedInView");
        }

 
    }
}