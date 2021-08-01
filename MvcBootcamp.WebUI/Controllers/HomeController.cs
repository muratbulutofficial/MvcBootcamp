using MvcBootcamp.BLL.Abstract;
using MvcBootcamp.BLL.DependencyResolvers.Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using PagedList;
using PagedList.Mvc;

namespace MvcBootcamp.WebUI.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        // GET: Home
        public HomeController()
        {
            _contentService = InstanceFactory.GetInstance<IContentService>();
            _authorService = InstanceFactory.GetInstance<IAuthorService>();
            _headlineService = InstanceFactory.GetInstance<IHeadlineService>();
        }
        private IContentService _contentService;
        private IAuthorService _authorService;
        private IHeadlineService  _headlineService;
        public ActionResult Index(string s,int p = 1)
        {
            if (!string.IsNullOrEmpty(s))
            {
                return View(_contentService.GetContentDetails().Where(x=>x.ContentText.ToLower().Contains(s)).ToPagedList(p, 10));
            }
            return View(_contentService.GetContentDetails().ToPagedList(p, 10));
        }
        [Route("search")]
        public ActionResult Search(string s)
        {
            string klm;

            if (!string.IsNullOrEmpty(s))
            {

                if (s.StartsWith("&"))
                {
                    klm = s.Substring(1).Trim().ToLower();
                    var author = _authorService.GetList().FirstOrDefault(x => x.Nickname.Equals(klm));
                    if (author != null)
                        return Redirect("/yazar/" + author.Nickname);
                }
                else if (s.StartsWith("#"))
                {
                    klm = s.Substring(1).Trim().ToLower();
                    var content = _contentService.GetContentDetails().Where(x => x.ContentText.Contains(klm));
                    if (content != null)
                        return Redirect("/?s="+klm);
                }
                else
                {
                    klm =s.Trim().ToLower();
                    var headline = _headlineService.GetList().FirstOrDefault(x => x.Text.ToLower().Equals(klm));
                    if (headline != null)
                        return Redirect("/baslik/" + headline.SeoUrl);
                }


            }
            return Redirect("/");
        }
    }
}