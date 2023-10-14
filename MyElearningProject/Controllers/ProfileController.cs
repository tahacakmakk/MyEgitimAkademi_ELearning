using MyElearningProject.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyElearningProject.Controllers
{
    public class ProfileController : Controller
    {
        ELearningContext context = new ELearningContext();

        public ActionResult Index()
        {
            var values = Session["CurrentMail"].ToString();
            ViewBag.mail = values;
			var student = context.Students.FirstOrDefault(x => x.Email == values);
			if (student != null)
			{
				ViewBag.name = student.Name;
				ViewBag.surname = student.Surname;
			}
			return View();
        }

        public ActionResult MyCourseList()
        {
            var values = Session["CurrentMail"].ToString();
            int id = context.Students.Where(x=>x.Email == values).Select(y=>y.StudentID).FirstOrDefault();
            var courseList = context.Processes.Where(x => x.StudentID == id).ToList();
            return View(courseList);
        }
    }
}