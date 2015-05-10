using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using SafeUp.Models.DbCollections;
using SafeUp.Models.DBPOSTGREs;
using SafeUp.Models.LoggedIn;
using SafeUp.Models.Utilities;

namespace SafeUp.Controllers
{
    public class LoggedInController : Controller
    {
        [HttpGet]
        public ActionResult LoggedIn()
        {
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoggedIn(string login, string password)
        {

            Table users;
            using (var handler = new PostgreHandler())
            {
                users = handler.GetUsersModel();
            }

            var passwordAsByteArray = Encoding.UTF8.GetBytes(password);
            var hashAsByteArray = new SHA512Managed().ComputeHash(passwordAsByteArray);

            var hash = Convert.ToBase64String(hashAsByteArray);



            foreach (var user in users.Rows.Values)
            {
                if (user.Columns["login"].ColumnyValue.ToString().Equals(login) &&
                    user.Columns["password"].ColumnyValue.Equals(hash)) ;
                {
                   Session.Add("login",login);

                    return View("~/Views/LoggedIn/LoggedInView.cshtml");
                }
             
            }
         


            return RedirectToAction("Index","Home");

        }

        [HttpPost]
        public ActionResult Register(string login, string password, string confirmPassword)
        {
            if (password != confirmPassword)
            {
                //return RedirectToAction("RegisterNewUser", "Home", new { errorCode = ErrorCode.UnequalPassword });
                return Redirect(Url.Action("RegisterNewUser", "Home", new {errorCode = ErrorCode.UnequalPassword}) + "#register");
            }
            if (Request.Form["checkedArchive"] != "false")
            {
                return Redirect(Url.Action("RegisterNewUser", "Home", new { errorCode = ErrorCode.UncheckedTermsOfUse }) + "#register");
            }

            var handler = new PostgreHandler();
            try
            {

                var passwordAsByteArray = Encoding.UTF8.GetBytes(password);
                var hashAsByteArray = new SHA512Managed().ComputeHash(passwordAsByteArray);

                var hash = Convert.ToBase64String(hashAsByteArray);

                var users = handler.GetUsersModel();

                foreach (var row in users.Rows.Values)
                {
                    if (row.Columns["login"].ColumnyValue.Equals(login))
                    {
                        return Redirect(Url.Action("RegisterNewUser", "Home", new {errorCode = ErrorCode.UserExists}) + "#register");
                    }
                }

                users.AddRow(login,hash,"0","1");

                return Redirect(Url.Action("RegisterNewUser", "Home", new { errorCode = ErrorCode.CorrectInformation }) + "#register");

            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
            finally
            {
               handler.Dispose();
            }
        }

        public ActionResult Logout(string targetPage)
        {
            
            Session.Abandon();

            //switch (targetPage)
            //{
            //    case "home":
            //    {
                    
            //    }
            //}
            return RedirectToAction("Index", "Home");

        }



    }
}