using MyElearningProject.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyElearningProject.Controllers
{
    public class AboutController : Controller
    {
        ELearningContext context = new ELearningContext();

        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult HeaderStart()
        {
            return PartialView();
        }
		public PartialViewResult Service()
		{
            var values = context.Services.ToList();
			return PartialView(values);
		}
		public PartialViewResult AboutUsPartial()
		{
			var values = context.AboutUs.ToList();
			return PartialView(values);
		}
		public PartialViewResult Team()
		{
			var values = context.Instructors.ToList();
			return PartialView(values);
		}
	}
}
