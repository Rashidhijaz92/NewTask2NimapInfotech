using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BAL;
using MODEL;
using NimapTask.Models;
using PagedList;
using PagedList.Mvc;

namespace NimapTask.Controllers
{
    public class ProductController : Controller
    {
        ProductCategoryDetail procat = new ProductCategoryDetail();
        ProductMasterr _Product = new ProductMasterr();


        // GET: Product
        public ActionResult Index(int? pageNumber)
        {
            ModelState.Clear();
            List<ProductModel> obj = _Product.FillProduct();

            return View(_Product.FillProduct().ToPagedList(pageNumber ?? 1, 10));
        }

        public ActionResult Create()
        {
            DataSet ds = new DataSet();
            ds = procat.GetAllcatMaster();
            ViewBag.CategoryName = ds.Tables[0].ToSelectList("CategoryId", "CategoryName");
            ViewBag.Product_Name = ds.Tables[1].ToSelectList("ProductId", "ProductName");
            return View();
        }
        [HttpPost]
        public ActionResult Create(ProductModel product)
        {
            try
            {
                if (ModelState.IsValid == true)
                {

                    bool check = _Product.CreateProduct(product);
                    if (check == true)
                    {
                        TempData["MsgInsert"] = "Record Inserted Successfully";
                        ModelState.Clear();
                        return RedirectToAction("Index");
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        //update displays data
        public ActionResult Edit(int ProductId)
        {
            var row = procat.GetAllProduct().Find(model => model.ProductId == ProductId);
            return View(row);
        }

        //update form data in db table
        [HttpPost]
        public ActionResult Edit(ProductModel product)
        {

            bool check = _Product.EditProduct(product);
            if (check == true)
            {
                TempData["MsgUpdate"] = "Record updated succefully.";
                ModelState.Clear();
                return RedirectToAction("Index");
            }

            return View();
        }

        //delete display data
        public ActionResult Delete(int ProductId)
        {
            var row = procat.GetAllProduct().Find(model => model.ProductId == ProductId);
            return View(row);
        }

        [HttpPost]
        public ActionResult Delete(int ProductId, ProductModel product)
        {
            bool check = _Product.DeleteProduct(ProductId);
            if (check == true)
            {
                TempData["MsgDelete"] = "Deleted succefully.";
                ModelState.Clear();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}