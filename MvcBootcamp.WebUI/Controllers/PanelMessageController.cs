using MvcBootcamp.BLL.Abstract;
using MvcBootcamp.BLL.DependencyResolvers.Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBootcamp.WebUI.Controllers
{
    public class PanelMessageController : Controller
    {
        public PanelMessageController()
        {
            _messageService = InstanceFactory.GetInstance<IMessageService>();
        }
        private IMessageService _messageService;
        // GET: PanelMessage
        [Route("message")]
        public ActionResult GetList()
        {
            if (Session["ActiveUser"] != null && Session["ActiveUserLevel"].ToString() == "1")
            {
                return View();

            }
            return Redirect("hata");
            
        
        }
        public PartialViewResult MessageList()
        {
            return PartialView(_messageService.GetList());

        } 
        public PartialViewResult MessageCount()
        {
            ViewBag.Count = _messageService.GetList().Where(x => x.isRead == false).Count();
            
            return PartialView(_messageService.GetList().Where(x=>x.isRead==false).ToList());

        }
        [Route("message/read/{id:int}")]
        public ActionResult Read(int id)
        {
            if (Session["ActiveUser"] != null && Session["ActiveUserLevel"].ToString() == "1")
            {
                var result = _messageService.Find(id);
                if (result.isRead == false)
                    _messageService.SetRead(result.Id);
                return View("Read", result);
            }
            return Redirect("hata");
            
        }
    }
}