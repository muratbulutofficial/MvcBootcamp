using MvcBootcamp.BLL.Concrete;
using MvcBootcamp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBootcamp.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        CategoryManager categoryManager = new CategoryManager();
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult GetList()
        {
            var categorylist = categoryManager.GetList();
            return View(categorylist);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View(); 
        }

        [HttpPost]
        public ActionResult Add(Category category)
        {
            categoryManager.Add(category);
            return RedirectToAction("GetList");
        }
    }
}