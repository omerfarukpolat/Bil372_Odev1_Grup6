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
            bool check = false;
            List<COUNTRY> countries = db.getCountry();
            foreach(var country in countries)
            {
                List<COUNTRY_CITY> countrycities = db.getCountryCity();
                foreach (var countrycity in countrycities)
                {
                    if (countrycity.CityID == mcity && country.Country_Code.Equals(mcountry)) check = true;
                }
            }
            if (!check) return RedirectToAction("Index", "Exception");
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

        // POST: Manufacturers/Update
        [HttpPost]
        public ActionResult Update(string mid,string mname, string maddress, string mcity, string mcountry)
        {
            List<COUNTRY> countries = db.getCountry();
            List<COUNTRY_CITY> countrycities = db.getCountryCity();
            bool check = false;
            foreach(var country in countries)
            {
                foreach(var countrycity in countrycities)
                {
                    if (country.Country_Code.Equals(mcountry) && countrycity.CityID == Int32.Parse(mcity)) check = true;
                }
            }
            if (!check) return RedirectToAction("Index", "Exception");
            db.updateManufacturers(Int32.Parse(mid),Int32.Parse(mcity),mcountry,mname,maddress);
            return View();

        }




        // GET: Manufacturers/Delete
        public ActionResult Delete(string mid)
        {
            if (mid != null)
                db.deleteFromManufacturers(Int32.Parse(mid));
            List<MANUFACTURERS> manufacturers = db.getManufacturers();
            return View(manufacturers);
        }


    }
}