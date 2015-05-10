using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SafeUp.Models.DbCollections;
using SafeUp.Models.DBPOSTGREs;
using SafeUp.Models.LoggedIn;

namespace SafeUp.Controllers
{
    public class LoggedInController : Controller
    {
      
     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoggedIn(string login, string password)
        {

            Table users;
            using (var handler = new PostgreHandler())
            {
                users = handler.GetUsersModel();
   
            }

            foreach (var user in users.Rows.Values)
            {
                if (user.Columns["login"].ColumnyValue.ToString().Equals(login) &&
                    user.Columns["password"].ColumnyValue.Equals(password.GetHashCode().ToString())) ;
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
            if (password != confirmPassword) return RedirectToAction("Index", "Home");
            var handler = new PostgreHandler();
            try
            {

                var hash = password.GetHashCode().ToString();
                var users = handler.GetUsersModel();
       

                users.AddRow(login,hash,"0","1");
                
                return View("~/Views/LoggedIn/LoggedInView.cshtml");

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



    }
}