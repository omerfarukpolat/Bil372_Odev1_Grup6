﻿using Bil372_Odev1_Grup6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bil372_Odev1_Grup6.Controllers
{
    public class FeaturesController : Controller
    {
        DatabaseController db = new DatabaseController("s");
        // GET: Features/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Features/Create
        [HttpPost]
        public ActionResult Create(string fname)
        {
            db.insertFeatures(fname);
            return View();

        }

        // GET: Features/Read
        public ActionResult Read()
        {
            List<FEATURES> features = db.getFeatures();
            return View(features);
        }

        // GET: Features/Update
        public ActionResult Update()
        {
            List<FEATURES> features = db.getFeatures();
            return View(features);
        }


        // GET: Features/Delete
        public ActionResult Delete()
        {
            List<FEATURES> features = db.getFeatures();
            return View(features);
        }


    }
}