using MyElearningProject.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyElearningProject.Controllers
{
    public class CourseUIController : Controller
    {
		ELearningContext context = new ELearningContext();	
        // GET: CourseUI
        public ActionResult Index()
        {
            return View();
        }
		public PartialViewResult HeadPartial()
		{
			return PartialView();
		}
		public PartialViewResult AllCoursePartial()
		{
			var values = context.Courses.ToList();
			return PartialView(values);
		}

		public ActionResult CourseDetails(int id)
		{
			var values = context.Courses.Where(x=>x.CourseID == id).FirstOrDefault();
			return View(values);
		}
	}
}