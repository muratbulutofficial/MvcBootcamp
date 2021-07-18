using MvcBootcamp.BLL.Abstract;
using MvcBootcamp.BLL.DependencyResolvers.Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBootcamp.WebUI.Controllers
{
    [Authorize]
    public class PanelController : Controller
    {
        public PanelController()
        {
            _skillService = InstanceFactory.GetInstance<ISkillService>();
            _messageService = InstanceFactory.GetInstance<IMessageService>();
        }
        private ISkillService _skillService;
        private IMessageService _messageService;
        // GET: Panel
        [Route("Panel")]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Skill()
        {
            return View(_skillService.GetList());
        }
        
    }
}