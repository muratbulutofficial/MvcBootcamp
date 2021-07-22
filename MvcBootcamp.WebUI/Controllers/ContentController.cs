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
    public class ContentController : Controller
    {
        // GET: Content
        public ContentController()
        {
            _contentService = InstanceFactory.GetInstance<IContentService>();
        }
        private IContentService _contentService;
        public PartialViewResult GetList()
        {
            return PartialView(_contentService.GetContentDetails());
        }

        [Route("baslik/{SeoUrl}")]
        public ActionResult Headline(string SeoUrl)
        {
            return View(_contentService.GetContentDetails().Where(x=>x.HeadlineSeoUrl.Equals(SeoUrl)).ToList());
        }
    }
}