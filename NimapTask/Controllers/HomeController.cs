using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BAL;
using PagedList.Mvc;
using PagedList;
using MODEL;
using System.Data;
using NimapTask.Models;

namespace NimapTask.Controllers
{
    public class HomeController : Controller
    {
        ProductMasterr Pro_bl_class = new ProductMasterr();

        CategoryMasterr Cat_balClass = new CategoryMasterr();

        ProductCategoryDetail procat = new ProductCategoryDetail();


        public ActionResult Index(int? pageNumber)
        {
            ModelState.Clear();
            return View(procat.GetAllProduct().ToPagedList(pageNumber ?? 1, 10));
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
        public ActionResult Create(CategoryModel CatModel)
        {
            try
            {
                if (ModelState.IsValid == true)
                {
                    bool check = procat.InsertCategory(CatModel);
                    if (check == true)
                    {
                        TempData["mgsInsert"] = "Record Inserted Successfully";
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










        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}