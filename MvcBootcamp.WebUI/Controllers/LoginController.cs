using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBootcamp.WebUI.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [Route("Login")]
        public ActionResult Index()
        {
            ViewBag.ErrorMessage = "E-Mail adresi veya şifre hatalı!";
            return View();
        }
    }
}