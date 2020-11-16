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
        DatabaseController db = new DatabaseController("1");

        // GET: Organisation/Create
        public ActionResult Create()
        {


            return View();
        }

        // POST: Organisation/Create
        [HttpPost]
        public ActionResult Create(string oname, string pw, string oaddress, string ocity, string odist, string otype)
        {
            List<ORGANISATIONS> o = db.getOrganisations();
            List<COUNTRY_CITY> countrycities = db.getCountryCity();
            bool check1 = false;

            foreach(var countrycity in countrycities)
            {
                if(countrycity.CityID == Int32.Parse(ocity)) check1 = true;
            }

            if (!check1) return RedirectToAction("Index", "Exception");



            if (o.Count == 0)
            {
                db.insertOrganisations(oname, Int32.Parse(pw), false, oaddress, Int32.Parse(ocity), odist, Int32.Parse(otype));

            }
            else
            {
                bool check = false;
                foreach (var org in o)
                {
                    if (org.ORG_ID == Int32.Parse(pw))
                    {
                        db.insertOrganisations(oname, Int32.Parse(pw), false, oaddress, Int32.Parse(ocity), odist, Int32.Parse(otype));
                        db.updateOrganisations(org.ORG_ID, org.ORG_NAME, org.PARENT_ORG, true, org.ORG_ADDRESS, org.ORG_CITY, org.ORG_DISTRICT, org.ORG_TYPE);
                        check = true;
                    }
                }
                if (!check)
                {
                    db.insertOrganisations(oname, Int32.Parse(pw), false, oaddress, Int32.Parse(ocity), odist, Int32.Parse(otype));

                }
            }
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
        public ActionResult Update(string oid, string oname, string pid, string oaddress, string ocity, string odist, string otype)
        {
            List<ORGANISATIONS> o = db.getOrganisations();
            bool isAbstract = false;

            foreach (var org in o)
            {
                if (org.ORG_ID == Int32.Parse(oid))
                {
                    isAbstract = org.ORG_ABSTRACT;
                }
            }
            db.updateOrganisations(Int32.Parse(oid), oname, Int32.Parse(pid), isAbstract, oaddress, Int32.Parse(ocity), odist, Int32.Parse(otype));
            return View();

        }


        // GET: Organisation/Delete
        public ActionResult Delete(string oid, string value)
        {
            List<ORGANISATIONS> o = db.getOrganisations();

            if (oid != null)
            {
                db.deleteFromOrganisations(Int32.Parse(oid), Int32.Parse(value));

                foreach (var org in o)
                {
                    bool check = false;
                    if (Int32.Parse(oid) == org.ORG_ID)
                    {
                        int id = org.ORG_ID;
                        foreach (var org2 in o)
                        {
                            if (org2.PARENT_ORG == id)
                            {
                                check = true;
                            }
                        }
                        if (!check)
                        {
                            foreach (var parent in o)
                            {
                                if (org.PARENT_ORG == parent.ORG_ID)
                                {
                                    db.updateOrganisations(parent.ORG_ID, parent.ORG_NAME, parent.PARENT_ORG, false, parent.ORG_ADDRESS, parent.ORG_CITY, parent.ORG_DISTRICT, parent.ORG_TYPE);

                                }
                            }
                        }
                    }
                }
            }
            return View(o);
        }


    }
}