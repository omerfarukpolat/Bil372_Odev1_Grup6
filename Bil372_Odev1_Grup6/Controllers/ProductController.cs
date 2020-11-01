using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bil372_Odev1_Grup6.Controllers
{
  
        public class ProductController : Controller
        {
            // GET: Product/Create
            public ActionResult Create()
            {


                return View();
            }

            // POST: Product/Create
            [HttpPost]
            public ActionResult Create(string pcode, string pname, string pshortname, string pcategory)
            {


                return View();

            }

            // GET: Product/Read
            public ActionResult Read()
            {
                return View();
            }

            // GET: Product/Update
            public ActionResult Update()
            {
                return View();
            }


            // GET: Product/Delete
            public ActionResult Delete()
            {
                return View();
            }


        }
    }
