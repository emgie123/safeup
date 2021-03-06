﻿using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;
using SafeUp.Models;
using SafeUp.Models.ActionFilters;
using SafeUp.Models.DBPOSTGREs;
using SafeUp.Models.SafeUpModels;
using SafeUp.Models.Utilities;
using SafeUp.Models.Utilities_and_Enums;

namespace SafeUp.Controllers
{
    public class LoggedInController : Controller
    {

        [HttpGet]
        [CustomSessionAuthorizeFilter]
        public ActionResult LogIn()
        {
            return View("~/Views/LoggedIn/LoggedInView.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn(string login, string password)
        {

            Table<User> users;
            using (var handler = new PostgreHandler())
            {
                users = handler.GetFilledUsersModel();
                
            }

            var passwordAsByteArray = Encoding.UTF8.GetBytes(password);
            var hashAsByteArray = new SHA256Managed().ComputeHash(passwordAsByteArray);

            var hash = ByteArrayToString(hashAsByteArray);

                                                                                                                                                    

            if (!users.Rows.Values.Any(user => user.Login.Equals(login) && user.Password.Equals(hash)))
                return Redirect(Url.Action("Login", "Home", new {errorCode = ErrorCode.InvalideUsernameOrPassword}) +"#home");


            int ID = (users.Rows.Values.FirstOrDefault(user => user.Login.Equals(login)).ID);
            ViewBag.UserName = login;
            Session.Add("ID", ID);
            Session.Add("Login", login);
            return View("~/Views/LoggedIn/LoggedInView.cshtml");

        }

        [HttpPost]
        public ActionResult Register(string login, string password, string confirmPassword)
        {
            if (password != confirmPassword)
            {
                return Redirect(Url.Action("RegisterNewUser", "Home", new {errorCode = ErrorCode.UnequalPassword}) + "#register");
            }
            if (!Request.Form["termsOfUse"].Contains("True"))
            {
                return Redirect(Url.Action("RegisterNewUser", "Home", new { errorCode = ErrorCode.UncheckedTermsOfUse }) + "#register");
            }

            var handler = new PostgreHandler();
            try
            {

                var passwordAsByteArray = Encoding.UTF8.GetBytes(password);
                var hashAsByteArray = new SHA256Managed().ComputeHash(passwordAsByteArray);

                var hash = ByteArrayToString(hashAsByteArray);

                var users = handler.GetFilledUsersModel();

                if (users.Rows.Values.Any(row => row.Login.Equals(login)))
                {
                
                    return Redirect(Url.Action("RegisterNewUser", "Home", new { errorCode = ErrorCode.UserExists }) + "#register");
                }

                users.AddRow(new User()
                {
                    Login = login,
                    Password = hash,
                    UsedSpace = 0,
                    AccountType = AccountTypeEnum.Free
                });

            }
            catch(Exception e)
            {
                return RedirectToAction("Index", "Home");
            }
            finally
            {
               handler.Dispose();
            }
            return Redirect(Url.Action("RegisterNewUser", "Home", new { errorCode = ErrorCode.CorrectInformation }) + "#register");
        }

     
        public ActionResult Logout(string targetPage)
        {
            
            Session.Abandon();

            string url = "";

            switch (targetPage)
            {
                case "home":
                    {
                        url = Url.Action("Index", "Home") + "Home#home";
                        break;
                    }
                case "about":
                {
                    url = Url.Action("Index", "Home") + "Home#about";
                    break;
                }

                case "download":
                {
                    url = Url.Action("Index", "Home") + "Home#download";
                    break;
                }

                case "contact":
                {
                    url = Url.Action("Index", "Home") + "Home#contact";
                    break;
                }

                case "register":
                {
                    url = Url.Action("Index", "Home") + "Home#register";
                    break;
                }
            
            }

            return Redirect(url);

        }

        public ActionResult AccessDenied(string targetPage)
        {

            return View();
        }



        public static string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }

    }
}