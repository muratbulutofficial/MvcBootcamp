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
            _userLevelService = InstanceFactory.GetInstance<IUserLevelService>();
        }
        private IAuthorService _authorService;
        private IUserLevelService _userLevelService;
        // GET: PanelAuthor
        [Route("author")]
        public ActionResult GetList()
        {
            return View(_authorService.GetAuthorDetail());
        }
        [HttpGet]
        [Route("author/new")]
        public ActionResult Add()
        {
            List<SelectListItem> levels = (from i in _userLevelService.GetList()
                                           select new SelectListItem
                                           {
                                            Text=i.LevelName,
                                            Value=i.Id.ToString()
                                           }).ToList();
            ViewBag.UserLevel = levels;
            return View();
        }
        [HttpPost]
        [Route("author/new")]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Author author)
        {
            try
            {
                var level = _userLevelService.GetList().FirstOrDefault(x=>x.Id.Equals(author.UserLevelId));
                author.UserLevelId = level.Id;
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
        [Route("author/update/{id:int}")]
        public ActionResult Update(int id)
        {
            List<SelectListItem> levels = (from i in _userLevelService.GetList()
                                           select new SelectListItem
                                           {
                                               Text = i.LevelName,
                                               Value = i.Id.ToString()
                                           }).ToList();
            ViewBag.UserLevel = levels;

            var author = _authorService.GetList().FirstOrDefault(x => x.Id.Equals(id));
            return View("Update",author);
        }
        [HttpPost]
        [Route("author/update/{id:int}")]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Author author)
        {
            try
            {
                var level = _userLevelService.GetList().FirstOrDefault(x => x.Id.Equals(author.UserLevelId));
                author.UserLevelId = level.Id;
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