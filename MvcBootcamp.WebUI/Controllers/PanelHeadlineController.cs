using MvcBootcamp.BLL.Abstract;
using MvcBootcamp.BLL.DependencyResolvers.Ninject;
using MvcBootcamp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBootcamp.WebUI.Controllers
{
    public class PanelHeadlineController : Controller
    {
        public PanelHeadlineController()
        {
            _headlineService = InstanceFactory.GetInstance<IHeadlineService>();
            _categoryService = InstanceFactory.GetInstance<ICategoryService>();
        }
        private IHeadlineService _headlineService;
        private ICategoryService _categoryService;
        // GET: PanelHeadline
        [Route("headline")]
        public ActionResult GetList()
        {
            if (Session["ActiveUser"] != null && Session["ActiveUserLevel"].ToString() == "1")
            {
                return View(_headlineService.GetHeadlineDetails());

            }
            return Redirect("hata");
        }
        [HttpGet]
        [Route("headline/new")]
        public ActionResult Add()
        {
            if (Session["ActiveUser"] != null && Session["ActiveUserLevel"].ToString() == "1")
            {
                List<SelectListItem> cat = (from i in _categoryService.GetList()
                                            select new SelectListItem
                                            {
                                                Text = i.Name,
                                                Value = i.Id.ToString()
                                            }).ToList();
                ViewBag.Category = cat;

                return View();

            }
            return Redirect("hata");
            
        }

        [HttpPost]
        [Route("headline/new")]
        [ValidateAntiForgeryToken]
        //[ValidateInput(false)] //ckeditör ile kayıt eklerken Request.form hatası almamak için kullanılır.
        public ActionResult Add(Headline headline)
        {
            try
            {
                headline.AuthorId =Convert.ToInt32(Session["ActiveUser"]);
                var ctg = _categoryService.GetList().FirstOrDefault(x=>x.Id.Equals(headline.CategoryId));
                headline.CategoryId = ctg.Id;
                _headlineService.Add(headline);
                return RedirectToAction("GetList");
            }
            catch (Exception exception)
            {
                ModelState.AddModelError("Text", exception.Message.Substring(25));
            }

            return View();
        }
        [HttpGet]
        [Route("headline/update/{id:int}")]
        public ActionResult Update(int id)
        {
            if (Session["ActiveUser"] != null && Session["ActiveUserLevel"].ToString() == "1")
            {
                List<SelectListItem> cat = (from i in _categoryService.GetList()
                                            select new SelectListItem
                                            {
                                                Text = i.Name,
                                                Value = i.Id.ToString()
                                            }).ToList();
                ViewBag.Category = cat;

                var headline = _headlineService.GetList().FirstOrDefault(x => x.Id.Equals(id));

                return View("Update", headline);

            }
            return Redirect("hata");
            
        }

        [HttpPost]
        [Route("headline/update/{id:int}")]
        [ValidateAntiForgeryToken]
        //[ValidateInput(false)] //ckeditör ile kayıt eklerken Request.form hatası almamak için kullanılır.
        public ActionResult Update(Headline headline)
        {
            try
            {
                headline.AuthorId =Convert.ToInt32(Session["ActiveUser"]);
                var ctg = _categoryService.GetList().FirstOrDefault(x=>x.Id.Equals(headline.CategoryId));
                headline.CategoryId = ctg.Id;
                _headlineService.Update(headline);
                return RedirectToAction("GetList");
            }
            catch (Exception exception)
            {
                ModelState.AddModelError("Text", exception.Message.Substring(25));
            }

            return View();
        }
        [HttpPost]
        public JsonResult Remove(int id)
        {
            var entity = _headlineService.Find(id);
            _headlineService.Remove(entity);
            return Json(JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SetStatus(int id)
        {
            _headlineService.SetStatus(id);
            return Json(JsonRequestBehavior.AllowGet);
        }
    }
}