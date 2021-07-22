using MvcBootcamp.BLL.Abstract;
using MvcBootcamp.BLL.Concrete;
using MvcBootcamp.BLL.DependencyResolvers.Ninject;
using MvcBootcamp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBootcamp.WebUI.Controllers
{
    [AllowAnonymous]
    public class CategoryController : Controller
    {
        // GET: Category

        public CategoryController()
        {
            _categoryService = InstanceFactory.GetInstance<ICategoryService>();
        }
        private ICategoryService _categoryService;

        public PartialViewResult GetList()
        {
            return PartialView(_categoryService.GetList());
        }
    }
}