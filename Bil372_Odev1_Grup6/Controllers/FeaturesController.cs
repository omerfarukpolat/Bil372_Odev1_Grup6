using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bil372_Odev1_Grup6.Controllers
{
    public class FeaturesController : Controller
    {
        // GET: Features/Create
        public ActionResult Create()
        {


            return View();
        }

        // POST: Features/Create
        [HttpPost]
        public ActionResult Create(string fname)
        {
            
           

            return View();

        }

        // GET: Features/Read
        public ActionResult Read()
        {
            return View();
        }

        // GET: Features/Update
        public ActionResult Update()
        {
            return View();
        }


        // GET: Features/Delete
        public ActionResult Delete()
        {
            return View();
        }


    }
}