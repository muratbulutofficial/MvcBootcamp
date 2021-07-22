using MvcBootcamp.BLL.Abstract;
using MvcBootcamp.BLL.DependencyResolvers.Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBootcamp.WebUI.Controllers
{
    [AllowAnonymous]
    public class HeadlineController : Controller
    {
        public HeadlineController()
        {
            _headlineService = InstanceFactory.GetInstance<IHeadlineService>();
        }
        private IHeadlineService _headlineService;
        // GET: Headline
        public PartialViewResult GetList()
        {
            return PartialView(_headlineService.GetList());
        }
    }
}