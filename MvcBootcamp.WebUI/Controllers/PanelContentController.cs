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

        [Route("contents")]
        public ActionResult GetList()
        {
            if (Session["ActiveUser"] != null && Session["ActiveUserLevel"].ToString() == "1")
            {
                return View(_contentService.GetContentDetails());
            }
            return Redirect("hata");
        }
        public ActionResult Writings(int id)
        {
            if (Session["ActiveUser"] != null && Session["ActiveUserLevel"].ToString() == "1")
            {
                var list = _contentService.GetContentDetails().Where(x => x.AuthorId.Equals(id)).ToList();

                return View(list);
            }
            return Redirect("hata");
            
        }
    }
}