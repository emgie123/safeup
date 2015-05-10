using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using SafeUp.Models.Utilities;

namespace SafeUp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View("Index");
        }

        public ActionResult RegisterNewUser(ErrorCode errorCode)
        {
            ViewBag.ErrorCode = errorCode;
            return View("Index");
            //return Redirect(Url.Action())
        }

        public ActionResult Login(ErrorCode errorCode)
        {
            ViewBag.ErrorCode = errorCode;
            return View("Index");
        }

    }
}