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
        // GET: Panel
        [Route("Panel")]
        public ActionResult Index()
        {
            return View();
        }
        
    }
}