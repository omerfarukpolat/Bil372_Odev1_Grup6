using Bil372_Odev1_Grup6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bil372_Odev1_Grup6.Controllers
{
  
        public class ProductController : Controller
        {
        DatabaseController db = new DatabaseController("1");
            // GET: Product/Create
            public ActionResult Create()
            {

                
                return View();
            }

            // POST: Product/Create
            [HttpPost]
            public ActionResult Create(string pcode, string pname, string pshortname, string pparentcode, string pcategory)
            {
              db.insertProduct(pcode, pname, pshortname, Int32.Parse(pparentcode) , true, pcategory, true);              
                return View();

            }

            // GET: Product/Read
            public ActionResult Read()
            {
            List<PRODUCT> products = db.getProduct();
                return View(products);
            }

            // GET: Product/Update
            public ActionResult Update()
            {
            List<PRODUCT> products = db.getProduct();
                return View(products);
            }

            // POST: Product/Update
            [HttpPost]
            public ActionResult Update(string scode,string pcode, string pname, string pshortname, string pparentcode, string pcategory)
            {
                db.updateProduct(Int32.Parse(scode), pcode, pname, pshortname, Int32.Parse(pparentcode) , true, pcategory, true);
                return View();

            }


            // GET: Product/Delete
            public ActionResult Delete(string scode, string value)
                {
                
                if(scode != null)
                    db.deleteFromProduct(Int32.Parse(scode),Int32.Parse(value));
                List<PRODUCT> products = db.getProduct();
                    return View(products);
                }
       


    }
    }
