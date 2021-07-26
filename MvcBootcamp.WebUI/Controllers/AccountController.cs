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
    [AllowAnonymous] // proje bazına çıkardığımız authorize dan bu controllerı muaf tuttuk.
    public class AccountController : Controller
    {
        public AccountController()
        {
            _authorService = InstanceFactory.GetInstance<IAuthorService>();
        }
        private IAuthorService _authorService;
        // GET: Account
        [Route("giris")]
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [Route("giris")]
        [HttpPost]
        public ActionResult Login(Author author)
        {

            if (_authorService.Login(author))
            {
                var aut=_authorService.GetList().FirstOrDefault(x => x.EMail.Equals(author.EMail));
                FormsAuthentication.SetAuthCookie(author.Nickname,false);
                Session.Add("ActiveUser", aut.Id);
                Session.Add("ActiveUserName", aut.Nickname);
                return RedirectToRoute("panel");
            }
            else
            {
                ViewBag.ErrorMessage = "E-Mail adresi veya şifre hatalı!";
                return View();
            }
        }
        [Route("kayit")]
        [HttpGet]
        public ActionResult Signup()
        {
            return View();
        }
        [Route("kayit")]
        [HttpPost]
        public ActionResult Signup(Author author)
        {
            try
            {
                _authorService.Add(author);
                FormsAuthentication.SetAuthCookie(author.Nickname, false);
                Session.Add("ActiveUser", author.Id);
                return View();
            }
            catch(Exception exception)
            {
                ModelState.AddModelError("NickName", exception.Message.Substring(25));
                return View();
            }
        }
        [Route("cikis")]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.RemoveAll();
            return RedirectToAction("Login");
        }
    }
}