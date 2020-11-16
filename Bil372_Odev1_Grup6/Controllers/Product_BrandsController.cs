using Bil372_Odev1_Grup6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bil372_Odev1_Grup6.Controllers
{
    
    public class Product_BrandsController : Controller
    {
        DatabaseController db = new DatabaseController("s");
        // GET: Product_Brands/Create
        public ActionResult Create()
        {


            return View();
        }

        // POST: Product_Brands/Create
        [HttpPost]
        public ActionResult Create(string mid,string scode,string bbarcode,string bname)
        {
            List<PRODUCT> products = db.getProduct();
            foreach(var p in products)
            {
                if(p.M_SYSCODE == Int32.Parse(scode))
                {
                    if(p.M_ABSTRACT == true)
                    {
                        break;
                    }
                    else
                    {
                        db.insertProductBrands(Int32.Parse(mid), Int32.Parse(scode), bbarcode, bname);

                    }
                }
            }
            return View();

        }


        // GET: Product_Brands/Read
        public ActionResult Read()
        {
            List<PRODUCT_BRANDS> productbrans = db.getProductBrands();
            return View(productbrans);
        }

        // GET: Product_Brands/Update
        public ActionResult Update()
        {
            List<PRODUCT_BRANDS> productbrans = db.getProductBrands();
            return View(productbrans);
        }

        // POST: Product_Brands/Update
        [HttpPost]
        public ActionResult Update(string mid, string scode, string bbarcode, string bname)
        {
            db.updateProductBrands(Int32.Parse(mid), Int32.Parse(scode), bbarcode, bname);
            return View();

        }


        // GET: Product_Brands/Delete
        public ActionResult Delete(string scode, string bcd,string value)
        {
            if (scode != null)
                db.deleteFromProductBrands(Int32.Parse(value),Int32.Parse(scode),bcd);
            List<PRODUCT_BRANDS> productbrans = db.getProductBrands();
            return View(productbrans);
        }


    }
}