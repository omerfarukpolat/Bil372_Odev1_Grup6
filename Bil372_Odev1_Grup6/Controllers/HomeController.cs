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
            DatabaseController dbc = new DatabaseController();
     //       dbc.insertCountry("230", "Turkiye");
        //    dbc.deleteFromProduct(5);
            //dbc.insertCountryCity("230", 06, "Ankara");
            //dbc.insertCountryCity("230", 08, "Antalya");
       //     dbc.updateCountryCity("230", 08, "Artvin");

            return View();
        }

        

        
    }
}