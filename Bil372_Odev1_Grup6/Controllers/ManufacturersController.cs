using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bil372_Odev1_Grup6.Controllers
{
    public class ManufacturersController : Controller
    {
        // GET: Manufacturers/Create
        public ActionResult Create()
        {


            return View();
        }

        // POST: Manufacturers/Create
        [HttpPost]
        public ActionResult Create(string mname, string maddress, string mcity, string mcountry)
        {
            

            return View();

        }

        // GET: Manufacturers/Read
        public ActionResult Read()
        {
            return View();
        }

        // GET: Manufacturers/Update
        public ActionResult Update()
        {
            return View();
        }


        // GET: Manufacturers/Delete
        public ActionResult Delete()
        {
            return View();
        }


    }
}