using MvcBootcamp.BLL.Abstract;
using MvcBootcamp.BLL.DependencyResolvers.Ninject;
using MvcBootcamp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcBootcamp.WebUI.Controllers
{
    public class LoginController : Controller
    {
        public LoginController()
        {
            _authorService = InstanceFactory.GetInstance<IAuthorService>();
        }
        private IAuthorService _authorService;

        // GET: Login
        [Route("Login")]
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [Route("Login")]
        [HttpPost]
        public ActionResult Index(Author author)
        {

            if (_authorService.PanelLogin(author))
            {
                FormsAuthentication.SetAuthCookie(author.Nickname, false);
                Session.Add("ActiveUser", author.Nickname);
                return RedirectToRoute("panel");
            }
            else
            {
                ViewBag.ErrorMessage = "E-Mail adresi veya şifre hatalı!";
                return View();
            }



        }
        [Route("Logout")]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.RemoveAll();
            return RedirectToRoute("login");
        }
    }
}