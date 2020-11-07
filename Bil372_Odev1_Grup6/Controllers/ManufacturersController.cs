using Bil372_Odev1_Grup6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bil372_Odev1_Grup6.Controllers
{
    public class ManufacturersController : Controller
    {
        DatabaseController db = new DatabaseController("s");
        // GET: Manufacturers/Create
        public ActionResult Create()
        {


            return View();
        }

        // POST: Manufacturers/Create
        [HttpPost]
        public ActionResult Create(string mname, string maddress, int mcity, string mcountry)
        {
            db.insertManufacturers(mname, maddress, mcity, mcountry);
            return View();

        }

        // GET: Manufacturers/Read
        public ActionResult Read()
        {
            List<MANUFACTURERS> manufacturers = db.getManufacturers();
            return View(manufacturers);
        }

        // GET: Manufacturers/Update
        public ActionResult Update()
        {
            List<MANUFACTURERS> manufacturers = db.getManufacturers();
            return View(manufacturers);
        }


        // GET: Manufacturers/Delete
        public ActionResult Delete()
        {
            List<MANUFACTURERS> manufacturers = db.getManufacturers();
            return View(manufacturers);
        }


    }
}