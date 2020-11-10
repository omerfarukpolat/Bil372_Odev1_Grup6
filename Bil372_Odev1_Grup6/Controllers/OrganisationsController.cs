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

        // POST: Organisation/Create
        [HttpPost]
        public ActionResult Create(string oname,string pw, string oaddress, string ocity, string odist, string otype)
        {
            
            db.insertOrganisations(5,oname, Int32.Parse(pw), true ,oaddress , Int32.Parse(otype));
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

        // POST: Product/Update
        [HttpPost]
        public ActionResult Update(string oid,string oname,string pid,string oaddress,string ocity,string odist, string otype)
        {
            db.updateOrganisations(Int32.Parse(oid),oname,Int32.Parse(pid),true,oaddress,Int32.Parse(ocity),Int32.Parse(otype));
            return View();

        }


        // GET: Organisation/Delete
        public ActionResult Delete(string oid,string value)
        {
            if (oid != null)
                db.deleteFromOrganisations(Int32.Parse(oid), Int32.Parse(value));
            List<ORGANISATIONS> organisations = db.getOrganisations();
            return View(organisations);
        }


    }
}