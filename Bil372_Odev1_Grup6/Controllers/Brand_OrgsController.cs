using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bil372_Odev1_Grup6.Models;

namespace Bil372_Odev1_Grup6.Controllers
{
    public class Brand_OrgsController : Controller
    {
        // GET: Brand_Orgs/Create

        DatabaseController db = new DatabaseController("s");
        public ActionResult Create()
        {
            return View();
        }

        // POST: Features/Create
        [HttpPost]
        public ActionResult Create(string orgid,string bcode,string quantity,string unit,string edate,string bprice,string inn,string outt)
        {
            db.insertBrandOrgs(Int32.Parse(orgid), Int32.Parse(bcode), float.Parse(unit, CultureInfo.InvariantCulture), float.Parse(bprice, CultureInfo.InvariantCulture), float.Parse(quantity, CultureInfo.InvariantCulture), float.Parse(inn, CultureInfo.InvariantCulture), float.Parse(outt, CultureInfo.InvariantCulture));
            

            return View();

        }


        // GET: Brand_Orgs/Search1
        public ActionResult Search1()
        {



            return View();
        }

        // POST: Brand_Orgs/Search1
        [HttpPost]
        public ActionResult Search1(string bname)
        {

            List<LINKINGBRANDORGS> model = db.searchWithBrandName(bname);

            return View(model);

        }

        // GET: Brand_Orgs/Search2
        public ActionResult Search2()
        {
            


            return View();
        }

        // POST: Brand_Orgs/Search2
        [HttpPost]
        public ActionResult Search2(string oname)
        {
            
            List<LINKINGBRANDORGS> model = db.searchWithOrgName(oname);
            
            return View(model);

        }

    }
}