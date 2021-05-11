using MvcBootcamp.BLL.Abstract;
using MvcBootcamp.BLL.DependencyResolvers.Ninject;
using MvcBootcamp.DAL.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBootcamp.WebUI.Controllers
{
    public class StatisticController : Controller
    {
        public StatisticController()
        {
            _categoryService = InstanceFactory.GetInstance<ICategoryService>();
            _headlineService = InstanceFactory.GetInstance<IHeadlineService>();
            _authorService = InstanceFactory.GetInstance<IAuthorService>();
        }
        private ICategoryService _categoryService;
        private IHeadlineService _headlineService;
        private IAuthorService _authorService;
        // GET: Statistic
        public ActionResult Index()
        {
            ViewBag.CategoryCount = _categoryService.GetList().Count();
            ViewBag.HeadlineOfSoftware = _headlineService.GetList().Where(x => x.CategoryId == 48).Count();
            ViewBag.AuthorGetByWord = _authorService.GetList().Where(x => x.Nickname.ToLower().Contains('a')).Count();
            Context context = new Context();
            ViewBag.MaxHeadline = context.Headlines.Max(x => x.Category.Name);

            ViewBag.StatusDifference = (
                _categoryService.GetList().Count(x => x.Status == true) -
                _categoryService.GetList().Count(x => x.Status == false));

            return View();
        }
    }
}