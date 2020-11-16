using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bil372_Odev1_Grup6.Models;
using System.Data.SqlClient;
using System.Configuration;

namespace Bil372_Odev1_Grup6.Controllers
{
    public class AccountController : Controller
    {

        DatabaseController db = new DatabaseController("s");
        // GET: Account
        // GET: Login
        public ActionResult Login()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["IMECE"].ConnectionString);
            bool exists;
            con.Open();
            var cmd = new SqlCommand();
            string sql = "select count (*) from INFORMATION_SCHEMA.TABLES where table_name = 'PRODUCT'";
            cmd.Connection = con;
            using var asd = new SqlCommand(sql, con);
            cmd.CommandText = sql;
            exists = (int)cmd.ExecuteScalar() == 1;
            con.Close();

            if (exists)
            {
                db = new DatabaseController("1");
            }
            else
            {
                db = new DatabaseController(1);
                db = new DatabaseController("1");
            }
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
                if((organisations[i].ORG_ID+"") == userModel.Password && organisations[i].ORG_NAME.Equals(userModel.UserName))
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
             db.insertOrganisations(oname, 0, true, oaddress, Int32.Parse(ocity), odist, Int32.Parse(otype));
            

            return RedirectToAction("Login", "Account");
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}