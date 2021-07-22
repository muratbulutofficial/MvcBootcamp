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
    [Authorize]
    public class PanelAuthorController : Controller
    {
        public PanelAuthorController()
        {
            _authorService = InstanceFactory.GetInstance<IAuthorService>();
        }
        private IAuthorService _authorService;
        // GET: PanelAuthor
      
        public ActionResult GetList()
        {
            return View(_authorService.GetAuthorDetail());
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Author author)
        {
            try
            {
                _authorService.Add(author);
                return RedirectToAction("GetList");
            }
            catch (Exception exception)
            {
                ModelState.AddModelError("NickName", exception.Message.Substring(25));
            }

            return View();
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            var author = _authorService.GetList().FirstOrDefault(x => x.Id.Equals(id));
            return View("Update",author);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Author author)
        {
            try
            {
                _authorService.Update(author);
                return RedirectToAction("GetList");
            }
            catch (Exception exception)
            {
                ModelState.AddModelError("NickName", exception.Message.Substring(25));
            }

            return View();
        }

        [HttpPost]
        public JsonResult SetStatus(int id)
        {
            _authorService.SetStatus(id);
            return Json(JsonRequestBehavior.AllowGet);
        }
    }
}