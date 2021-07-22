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
            _authorService = InstanceFactory.GetInstance<IAuthorService>();
        }
        private IContentService _contentService;
        private IAuthorService _authorService;
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetList()
        {
            return View(_contentService.GetContentDetails());
        }
        public ActionResult Writings(int id)
        {
            var result = _authorService.GetList().Where(x=>x.Id.Equals(id)).FirstOrDefault();
            var list = _contentService.GetContentDetails().Where(x => x.AuthorName.Equals(result.Nickname)).ToList();
            if (list != null)
                return View(list);

            return View();
        }
    }
}