using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bil372_Odev1_Grup6.Models;

namespace Bil372_Odev1_Grup6.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Register()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Authorise(Models.USER userModel)
        {
            // using (LoginDataBaseEntities db = new LoginDataBaseEntities())
            //{
            //var userDetails = db.Users.Where(x => x.UserName == userModel.UserName && x.Password == userModel.Password).FirstOrDefault();


            string username = "a";
            string password = "1";

            if (username != userModel.UserName || password != userModel.Password)
            {
                userModel.LoginErrorMessage = "Wrong username or password";
                return View("Login", userModel);
            }
            else
            {
                Session["userID"] = username;
                Session["userName"] = password;
                return RedirectToAction("Index", "Home");
            }


        }
        // POST: Account/Register
        [HttpPost]
        public ActionResult Register(string uname, string pw, string oname, string mname, string omail, string otel, string ofax, string oaddress)
        {
            

            return RedirectToAction("Login", "Account");
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}