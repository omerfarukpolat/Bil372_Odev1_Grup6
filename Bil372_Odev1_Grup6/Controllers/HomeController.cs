using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Data.SqlClient;
using System.Configuration;

namespace Bil372_Odev1_Grup6.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            DatabaseController dbc = new DatabaseController("1");
           // dbc.searchWithOrgName("adas");
            return View();
        }

        

        
    }
}