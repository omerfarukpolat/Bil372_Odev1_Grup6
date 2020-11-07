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
        DatabaseController db = new DatabaseController("s");
            // GET: Product/Create
            public ActionResult Create()
            {


                return View();
            }

            // POST: Product/Create
            [HttpPost]
            public ActionResult Create(string pcode, string pname, string pshortname, string pcategory)
            {
              db.insertProduct(pcode, pname, pshortname, pcode, true, pcategory, true);              
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


            // GET: Product/Delete
            public ActionResult Delete()
            {
            List<PRODUCT> products = db.getProduct();
                return View(products);
            }


        }
    }
