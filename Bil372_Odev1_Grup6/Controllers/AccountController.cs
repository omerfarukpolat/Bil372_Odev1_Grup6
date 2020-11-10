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

        DatabaseController db = new DatabaseController("s");
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
            List<ORGANISATIONS> organisations = db.getOrganisations();

            string username = "";
            string password = "";

            for(int i = 0; i < organisations.Count; i++)
            {
                if((organisations[i].ORG_ID+"") == userModel.Password && organisations[i].ORG_NAME.Equals(userModel.UserName) && organisations[i].PARENT_ORG == 0)
                {
                    username = userModel.UserName;
                    password = userModel.Password;
                }
            }

            if (username != userModel.UserName || password != userModel.Password)
            {
                userModel.LoginErrorMessage = "Wrong username or password";
                return View("Login", userModel);
            }
            else
            {
                Session["userName"] = username;
                Session["userID"] = password;
                return RedirectToAction("Index", "Home");
            }


        }
        // POST: Account/Register
        [HttpPost]
        public ActionResult Register(string oname, string oaddress, string ocity, string odist, string otype)
        {
            db.insertOrganisations(1, oname, 0, true, oaddress, Int32.Parse(otype));
            

            return RedirectToAction("Login", "Account");
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}