using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bil372_Odev1_Grup6.Models;
using System.Globalization;


namespace Bil372_Odev1_Grup6.Controllers
{
    public class FlowController : Controller
    {
        DatabaseController db = new DatabaseController("1");

        // GET: Flow/inTransfer

        public ActionResult InTransfer()
        {
            List<BRAND_ORGS> model = db.getBrandOrgs();
            return View(model);
        }

        // POST: Flow/inTransfer
        [HttpPost]
        public ActionResult InTransfer(string sourceid, string bbarcode , string quantity)
        {
            db.insertINFlow(Int32.Parse(sourceid), bbarcode, float.Parse(quantity, CultureInfo.InvariantCulture), DateTime.Now);
            List<BRAND_ORGS> brandorgs = db.getBrandOrgs();
            foreach(var brandorg in brandorgs)
            {
                if(brandorg.ORG_ID == Int32.Parse(sourceid))
                {
                    db.updateBrandOrgs(brandorg.LOT_ID, brandorg.ORG_ID, bbarcode, (float)brandorg.UNIT, (float)brandorg.BASEPRICE, (float)(brandorg.INNN - float.Parse(quantity, CultureInfo.InvariantCulture)), (float)(brandorg.OUTTTT + float.Parse(quantity, CultureInfo.InvariantCulture)));
                }
            }
            return View();
        }

        // GET: Flow/outTransfer

        public ActionResult OutTransfer()
        {
            List<BRAND_ORGS> model = db.getBrandOrgs();
            return View(model);
        }

        // POST: Flow/outTransfer
        [HttpPost]
        public ActionResult OutTransfer(string sourceid, string bbarcode , string targetid, string quantity)
        {
            db.insertOUTFlow(Int32.Parse(sourceid), Int32.Parse(targetid), bbarcode, float.Parse(quantity, CultureInfo.InvariantCulture), DateTime.Now);
            List<BRAND_ORGS> brandorgs = db.getBrandOrgs();
            foreach(var brandorg in brandorgs)
            {
                if(brandorg.ORG_ID == Int32.Parse(sourceid)){
                    db.updateBrandOrgs(brandorg.LOT_ID, brandorg.ORG_ID, brandorg.BRAND_BARCODE, (float)brandorg.UNIT, (float)brandorg.BASEPRICE, (float)brandorg.INNN, (float)(brandorg.OUTTTT - float.Parse(quantity, CultureInfo.InvariantCulture)));
                }
                if(brandorg.ORG_ID == Int32.Parse(targetid))
                {
                    db.updateBrandOrgs(brandorg.LOT_ID, brandorg.ORG_ID, brandorg.BRAND_BARCODE, (float)brandorg.UNIT, (float)brandorg.BASEPRICE, (float)(brandorg.INNN +float.Parse(quantity, CultureInfo.InvariantCulture)), (float)(brandorg.OUTTTT));

                }
            }
            return View();
        }

       


    }
}