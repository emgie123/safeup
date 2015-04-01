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
     
        public ActionResult LoggedIn()
        {
            Session.Add("user",new User());
            return View("~/Views/LoggedIn/LoggedInView.cshtml");
        }
    }
}