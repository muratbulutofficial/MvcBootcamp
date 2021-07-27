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
            if (Session["ActiveUser"] != null && Session["ActiveUserLevel"].ToString() == "1")
            {
                return View(_authorService.GetAuthorDetail());
            }
            return Redirect("hata");
        }
        [HttpGet]
        [Route("author/new")]
        public ActionResult Add()
        {
            List<SelectListItem> levels = (from i in _userLevelService.GetList()
                                           select new SelectListItem
                                           {
                                               Text = i.LevelName,
                                               Value = i.Id.ToString()
                                           }).ToList();
            ViewBag.UserLevel = levels;


            if (Session["ActiveUser"] != null && Session["ActiveUserLevel"].ToString() == "1")
            {
                return View();
            }
            return Redirect("hata");

        }
        [HttpPost]
        [Route("author/new")]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Author author)
        {
            try
            {

                var level = _userLevelService.GetList().FirstOrDefault(x => x.Id.Equals(author.UserLevelId));
                author.UserLevelId = level.Id;
                _authorService.Add(author);
                return RedirectToAction("GetList");
            }
            catch (Exception exception)
            {
                ModelState.AddModelError("Nickname", exception.Message.Substring(25));
            }

            return View();
        }
        [HttpGet]
        [Route("author/update/{id:int}")]
        public ActionResult Update(int id)
        {
            if (Session["ActiveUser"] != null && Session["ActiveUserLevel"].ToString() == "1")
            {
                List<SelectListItem> levels = (from i in _userLevelService.GetList()
                                               select new SelectListItem
                                               {
                                                   Text = i.LevelName,
                                                   Value = i.Id.ToString()
                                               }).ToList();
                ViewBag.UserLevel = levels;

                var author = _authorService.GetList().FirstOrDefault(x => x.Id.Equals(id));


                return View("Update", author);
            }
            return Redirect("hata");
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