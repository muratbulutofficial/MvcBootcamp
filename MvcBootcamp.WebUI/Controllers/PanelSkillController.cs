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
    public class PanelSkillController : Controller
    {
        public PanelSkillController()
        {
            _skillService = InstanceFactory.GetInstance<ISkillService>();
        }
        private ISkillService _skillService;

        // GET: PanelSkill
        [Route("skill")]
        public ActionResult GetList()
        {
            if (Session["ActiveUser"] != null && Session["ActiveUserLevel"].ToString() == "1")
            {
                return View(_skillService.GetList());
            }
            return Redirect("hata");
          
        }
        [HttpGet]
        [Route("skill/new")]
        public ActionResult Add()
        {
            if (Session["ActiveUser"] != null && Session["ActiveUserLevel"].ToString() == "1")
            {
                return View();
            }
            return Redirect("hata");
        }
        [HttpPost]
        [Route("skill/new")]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Skill skill)
        {
            _skillService.Add(skill);
            return RedirectToAction("GetList");
        }
        [HttpGet]
        [Route("skill/update/{id:int}")]
        public ActionResult Update(int id)
        {
            if (Session["ActiveUser"] != null && Session["ActiveUserLevel"].ToString() == "1")
            {
                var skill = _skillService.GetList().FirstOrDefault(x => x.Id.Equals(id));
                return View("Update", skill);
            }
            return Redirect("hata");
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Skill skill)
        {
            _skillService.Update(skill);
            return RedirectToAction("GetList");
        }
        [Route("skill/remove/{id:int}")]
        public ActionResult Remove(Skill skill)
        {
            if (Session["ActiveUser"] != null && Session["ActiveUserLevel"].ToString() == "1")
            {
                _skillService.Remove(skill);
                return RedirectToAction("GetList");
            }
            return Redirect("hata");
            
        }
    }
}