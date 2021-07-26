using MvcBootcamp.BLL.Abstract;
using MvcBootcamp.BLL.DependencyResolvers.Ninject;
using MvcBootcamp.Entities.Concrete;
using MvcBootcamp.WebUI.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBootcamp.WebUI.Controllers
{
    [Authorize]
    public class PanelCategoryController : Controller
    {
        public PanelCategoryController()
        {
            _categoryService = InstanceFactory.GetInstance<ICategoryService>();
        }
        private ICategoryService _categoryService;

        // GET: PanelCategory
        [Route("category")]
        public ActionResult GetList()
        {
            return View(_categoryService.GetList());
        }
        
        [HttpGet]
        [Route("category/new")]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("category/new")]
        [ValidateAntiForgeryToken]
        //[ValidateInput(false)] //ckeditör ile kayıt eklerken Request.form hatası almamak için kullanılır.
        public ActionResult Add(Category category)
        {
            try
            {
                _categoryService.Add(category);
                return RedirectToAction("GetList");
            }
            catch (Exception exception)
            {
                ModelState.AddModelError("Name", exception.Message.Substring(25));
            }

            return View();
        }

        [HttpGet]
        [Route("category/update/{id:int}")]
        public ActionResult Update(int id)
        {
            return View("Update", _categoryService.Find(id));
        }
        [HttpPost]
        [Route("category/update/{id:int}")]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)] //ckeditör ile kayıt eklerken Request.form hatası almamak için kullanılır.
        public ActionResult Update(Category category)
        {
            try
            {
                _categoryService.Update(category);
                return RedirectToAction("GetList");
            }
            catch (Exception exception)
            {
                ModelState.AddModelError("Name", exception.Message.Substring(25));
            }

            return View();
        }

        [HttpPost]
        public JsonResult Remove(int id)
        {
            var entity = _categoryService.Find(id);
            _categoryService.Remove(entity);
            return Json(JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SetStatus(int id)
        {
            _categoryService.SetStatus(id);
            return Json(JsonRequestBehavior.AllowGet);
        }

    }

}
