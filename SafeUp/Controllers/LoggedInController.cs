using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SafeUp.Models.LoggedIn;

namespace SafeUp.Controllers
{
    public class LoggedInController : Controller
    {
      
     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoggedIn(string login, string password)
        {

            if (login == "user" && password == "test") return View("~/Views/LoggedIn/LoggedInView.cshtml");
            
            
            return RedirectToAction("Index","Home");

        }



    }
}