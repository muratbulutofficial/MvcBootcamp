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
    public class PanelHeadlineController : Controller
    {
        public PanelHeadlineController()
        {
            _headlineService = InstanceFactory.GetInstance<IHeadlineService>();
        }
        private IHeadlineService _headlineService;
        // GET: PanelHeadline
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetList()
        {
            return View(_headlineService.GetHeadlineDetails());
        }
        [HttpPost]
        public JsonResult SetStatus(int id)
        {
            _headlineService.SetStatus(id);
            return Json(JsonRequestBehavior.AllowGet);
        }
    }
}