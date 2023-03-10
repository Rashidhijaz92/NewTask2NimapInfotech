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
    public class CategoryController : Controller
    {
        CategoryMasterr Cat_balClass = new CategoryMasterr();
        ProductCategoryDetail procat = new ProductCategoryDetail();

        // GET: Category
        public ActionResult Index(int? pageNumber)
        {
            ModelState.Clear();
            List<CategoryModel> obj = Cat_balClass.FillCategory();
            return View(Cat_balClass.FillCategory().ToPagedList(pageNumber ?? 1, 10));
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
        public ActionResult Create(Category category)

        {
            try
            {
                if (ModelState.IsValid == true)
                {

                    bool check = Cat_balClass.CreateCategory(category);
                    if (check == true)
                    {
                        TempData["MsgInser"] = "Record Inserted Successfully";
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

        //Fetch the data
        public ActionResult Edit(int CategoryId)
        {
            var row = Cat_balClass.FillCategory().Find(model => model.CategoryId == CategoryId);
            return View(row);
        }

        //update UI To DatBase
        [HttpPost]
        public ActionResult Edit(int CategoryId, Category prd)
        {
            if (ModelState.IsValid == true)
            {
                bool check = Cat_balClass.EditCategory(prd, CategoryId);
                if (check == true)
                {
                    TempData["MsgUpdate"] = "Record updated";
                    ModelState.Clear();
                    return RedirectToAction("Index");
                }

            }
            return View();
        }

        //delete display data
        public ActionResult Delete(int CategoryId)
        {
            var row = Cat_balClass.FillCategory().Find(model => model.CategoryId == CategoryId);
            return View(row);
        }

        [HttpPost]
        public ActionResult Delete(int CategoryId, CategoryModel cat)
        {
            bool check = Cat_balClass.DeleteCategor(CategoryId);
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
