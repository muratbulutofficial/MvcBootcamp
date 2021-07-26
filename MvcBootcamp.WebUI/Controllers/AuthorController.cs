﻿using MvcBootcamp.BLL.Abstract;
using MvcBootcamp.BLL.DependencyResolvers.Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBootcamp.WebUI.Controllers
{
    [AllowAnonymous]
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
        [Route("yazar/{name}")]
        public ActionResult Index(string name)
        {
            var author = _authorService.GetList().FirstOrDefault(x=>x.Nickname.Equals(name));
            ViewBag.Image = author.Image;
            ViewBag.Nickname = author.Nickname;
            ViewBag.About = author.About;
            return View(_contentService.GetContentDetails().Where(x=>x.AuthorId.Equals(author.Id)).ToList());
        }
    }
}