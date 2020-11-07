using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bil372_Odev1_Grup6.Models;

namespace Bil372_Odev1_Grup6.Controllers
{
    public class OrganisationsController : Controller
    {
        DatabaseController db = new DatabaseController("s");
        // GET: Organisation/Create
        public ActionResult Create()
        {


            return View();
        }

        

        // GET: Organisation/Read
        public ActionResult Read()
        {
            List<ORGANISATIONS> organisations = db.getOrganisations();
            return View(organisations);
        }

        // GET: Organisation/Update
        public ActionResult Update()
        {
            List<ORGANISATIONS> organisations = db.getOrganisations();
            return View(organisations);
        }


        // GET: Organisation/Delete
        public ActionResult Delete()
        {
            List<ORGANISATIONS> organisations = db.getOrganisations();
            return View(organisations);
        }


    }
}