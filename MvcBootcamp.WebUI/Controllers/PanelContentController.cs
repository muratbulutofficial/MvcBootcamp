using MvcBootcamp.BLL.Abstract;
using MvcBootcamp.BLL.DependencyResolvers.Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBootcamp.WebUI.Controllers
{
    public class PanelContentController : Controller
    {
        // GET: PanelContent
        public PanelContentController()
        {
            _contentService = InstanceFactory.GetInstance<IContentService>();
        }
        private IContentService _contentService;
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetList()
        {
            return View(_contentService.GetContentDetails());
        }
    }
}