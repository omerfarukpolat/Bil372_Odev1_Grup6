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
            List<PRODUCT> p = db.getProduct();
            if (p.Count == 0)
            {
                db.insertProduct(pcode, pname, pshortname, "NULL", false, pcategory, true);
            }
            else
            {
                Boolean check = false;
                foreach (var product in p)
                {

                    if (product.M_CATEGORY.Equals(pparentcode))
                    {
                        db.insertProduct(pcode, pname, pshortname, product.M_CODE, false, pcategory, true);
                        db.updateProduct(product.M_SYSCODE, product.M_CODE, product.M_NAME, product.M_SHORTNAME, product.M_PARENTCODE, true, product.M_CATEGORY, true);
                        check = true;
                    }

                }
                if (!check)
                {
                    db.insertProduct(pcode, pname, pshortname, "NULL", false, pcategory, true);
                }
            }
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
            List<PRODUCT> products = db.getProduct();
            bool isAbstract = false;

            foreach(var product in products)
            {
                if (Int32.Parse(scode) == product.M_SYSCODE)
                {
                    isAbstract = product.M_ABSTRACT;
                }
            }
                 db.updateProduct(Int32.Parse(scode), pcode, pname, pshortname, pparentcode , isAbstract, pcategory, true);
                return View();

            }


            // GET: Product/Delete
            public ActionResult Delete(string scode, string value)
                {

            List<PRODUCT> products = db.getProduct();
            if (scode != null)
            {
                db.deleteFromProduct(Int32.Parse(scode), Int32.Parse(value));
                 
                 foreach (var product in products)
                {
                    bool check = false;
                    if (Int32.Parse(scode) == product.M_SYSCODE)
                    {
                        string mcode = product.M_CODE;
                        foreach (var product2 in products)
                        {
                            if (product2.M_PARENTCODE.Equals(mcode))
                            {
                                check = true;
                            }
                        }
                        if (!check)
                        {
                            foreach (var parent in products)
                            {
                                if (product.M_PARENTCODE.Equals(parent.M_CODE))
                                {
                                    db.updateProduct(parent.M_SYSCODE, parent.M_CODE, parent.M_NAME, parent.M_SHORTNAME, parent.M_PARENTCODE, false, parent.M_CATEGORY, true);
                                }
                            }
                        }
                    }
                } 
            }
            return View(products);
                }
        
        




    }
    }
