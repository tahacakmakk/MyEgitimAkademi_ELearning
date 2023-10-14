using MyElearningProject.DAL.Context;
using MyElearningProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyElearningProject.Controllers
{
    public class CourseScorController : Controller
    {
        ELearningContext context = new ELearningContext();
		[HttpGet]
		public ActionResult Index(int id)
        {
            var values = context.CourseScors.ToList();
			ViewBag.Ids = id;	
			return View(values);
			
        }
		[HttpPost]
		public ActionResult Index(CourseScor scor)
		{
			var values = context.CourseScors.Find(scor.CourseScorID);
			scor.StudentID = 8;
			context.CourseScors.Add(scor);
			context.SaveChanges();
			return RedirectToAction("Index","Course");
		}
	}
}