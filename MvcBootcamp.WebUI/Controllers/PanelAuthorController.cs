using MvcBootcamp.BLL.Abstract;
using MvcBootcamp.BLL.DependencyResolvers.Ninject;
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
        }
        private IAuthorService _authorService;
        // GET: PanelAuthor
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetList()
        {
            return View(_authorService.GetList());
        }
    }
}