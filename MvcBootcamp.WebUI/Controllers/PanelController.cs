using MvcBootcamp.BLL.Abstract;
using MvcBootcamp.BLL.DependencyResolvers.Ninject;
using MvcBootcamp.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBootcamp.WebUI.Controllers
{
    public class PanelController : Controller
    {

        public PanelController()
        {
			_headlineService = InstanceFactory.GetInstance<IHeadlineService>();
        }
		private IHeadlineService _headlineService;
        // GET: Panel
        [Route("Panel")]
        public ActionResult Index()
        {
            if (Session["ActiveUser"]!=null && Session["ActiveUserLevel"].ToString()=="1")
            {
                return View(new Calender());
            }
            return Redirect("hata");

        }
		public JsonResult GetEvents(DateTime start, DateTime end)
		{
			var viewModel = new Calender();
			var events = new List<Calender>();
			start = DateTime.Today.AddDays(-14);
			end = DateTime.Today.AddDays(-14);

			foreach (var item in _headlineService.GetList())
			{
				events.Add(new Calender()
				{
					title = item.Text,
					start = item.CreationDate,
					end = item.CreationDate.AddDays(-14),
					allDay = false
				});

				start = start.AddDays(7);
				end = end.AddDays(7);
			}


			return Json(events.ToArray(), JsonRequestBehavior.AllowGet);
		}


	}
}