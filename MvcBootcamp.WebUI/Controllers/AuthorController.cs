using MvcBootcamp.BLL.Abstract;
using MvcBootcamp.BLL.DependencyResolvers.Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using MvcBootcamp.Entities.Concrete;
using System.IO;

namespace MvcBootcamp.WebUI.Controllers
{
    public class AuthorController : Controller
    {
        public AuthorController()
        {
            _authorService = InstanceFactory.GetInstance<IAuthorService>();
            _contentService = InstanceFactory.GetInstance<IContentService>();
        }
        private IAuthorService _authorService;
        private IContentService _contentService;

        // GET: Author
        [AllowAnonymous]
        [Route("yazar/{name}")]
        public ActionResult Index(string name)
        {
            var author = _authorService.GetList().FirstOrDefault(x=>x.Nickname.Equals(name));
            ViewBag.Image = author.Image;
            ViewBag.Nickname = author.Nickname;
            ViewBag.About = author.About;
            return View(_contentService.GetContentDetails().Where(x=>x.AuthorId.Equals(author.Id)).ToList());
        }
        [Route("profil")]
        public ActionResult Profiles(int p=1)
        {
            if (Session["ActiveUser"] != null)
            {
                int id = Convert.ToInt32(Session["ActiveUser"]);
                var author = _authorService.GetList().FirstOrDefault(x => x.Id.Equals(id));
                ViewBag.Image = author.Image;
                ViewBag.Nickname = author.Nickname;
                ViewBag.About = author.About;
                return View(_contentService.GetContentDetails().Where(x => x.AuthorId.Equals(id)).ToPagedList(p,5));
            }
            return Redirect("hata");
            
        }
        [Route("guncelle")]
        [HttpPost]
        public ActionResult Update(Author author)
        {
            if (Session["ActiveUser"] != null)
            {
                int id = Convert.ToInt32(Session["ActiveUser"]);
                var aut = _authorService.GetList().FirstOrDefault(x=>x.Id.Equals(id));
                aut.About = author.About.Trim();
                _authorService.Update(aut);
                return Redirect("profil");
            }
            return Redirect("hata");

        }
        [Route("resim-yukle")]
        [HttpPost]
        public ActionResult Upload(Author author )
        {
            if (Session["ActiveUser"] != null)
            {
                if (Request.Files.Count > 0)
                {
                    string resimadi = Path.GetFileName(Request.Files[0].FileName);
                    string adres = Server.MapPath("~/Content/uploads/" + resimadi);
                    Request.Files[0].SaveAs(adres);
                    author.Image = @"Content/uploads/" + resimadi;
                }
                int id = Convert.ToInt32(Session["ActiveUser"]);
                var aut = _authorService.GetList().FirstOrDefault(x=>x.Id.Equals(id));
                aut.Image = author.Image;
                _authorService.Update(aut);
                Session["ActiveUserImage"] = aut.Image;
                return Redirect("profil");
            }
            return Redirect("hata");

        }
    }
}