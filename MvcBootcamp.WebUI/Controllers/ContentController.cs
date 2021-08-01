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

namespace MvcBootcamp.WebUI.Controllers
{
    public class ContentController : Controller
    {
        // GET: Content
        public ContentController()
        {
            _contentService = InstanceFactory.GetInstance<IContentService>();
        }
        private IContentService _contentService;
        [AllowAnonymous]
        [Route("baslik/{SeoUrl}")]
        public ActionResult Headline(string SeoUrl, int p = 1)
        {
            var headline = _contentService.GetContentDetails().FirstOrDefault(x => x.HeadlineSeoUrl.Equals(SeoUrl));
            ViewBag.HeadlineName = headline.HeadlineName;
            ViewBag.HeadlineSeoUrl = headline.HeadlineSeoUrl;
            return View(_contentService.GetContentDetails().Where(x => x.HeadlineSeoUrl.Equals(SeoUrl)).ToPagedList(p, 10));
        }
        [Route("yeni-entry/{SeoUrl}")]
        [HttpGet]
        public ActionResult Add(string SeoUrl)
        {
            if (Session["ActiveUser"]!=null)
            {
                var headline = _contentService.GetContentDetails().FirstOrDefault(x => x.HeadlineSeoUrl.Equals(SeoUrl));
                ViewBag.HeadlineName = headline.HeadlineName;
                ViewBag.HeadlineId = headline.HeadlineId;
                return View();
            }
            return Redirect("hata");
        }
        [Route("yeni-entry/{SeoUrl}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Add(Content content)
        {
            try
            {
                content.AuthorId = Convert.ToInt32(Session["ActiveUser"].ToString());
                _contentService.Add(content);
                return Redirect("/");
            }
            catch (Exception exception)
            {

                ModelState.AddModelError("Text", exception.Message.Substring(25));
            }

            var headline = _contentService.GetContentDetails().FirstOrDefault(x => x.HeadlineId.Equals(content.HeadlineId));
            ViewBag.HeadlineId = headline.HeadlineId;
            ViewBag.HeadlineName = headline.HeadlineName;

            return View();
        }
        [Route("duzenle-entry/{id:int}")]
        [HttpGet]
        public ActionResult Update(int id)
        {
            if (Session["ActiveUser"] != null)
            {
                var content = _contentService.GetContentDetails().FirstOrDefault(x => x.ContentId.Equals(id));
                ViewBag.HeadlineName = content.HeadlineName;
                ViewBag.HeadlineId = content.HeadlineId;

                return View("Update",content);
            }
            return Redirect("hata");
        }
    }
}