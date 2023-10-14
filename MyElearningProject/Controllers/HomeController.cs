using MyElearningProject.DAL.Context;
using MyElearningProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyElearningProject.Controllers
{
    public class HomeController : Controller
    {
		ELearningContext context = new ELearningContext();

		// GET: Home
		public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult Carousel()
        {
			var values = context.Carousels.ToList();
            return PartialView(values);
        }
        public PartialViewResult Service()
        {
			var values = context.Services.ToList();
            return PartialView(values);
        }
		public PartialViewResult AboutPartial()
		{
			var values = context.AboutUs.ToList();
			return PartialView(values);
		}
		public PartialViewResult CategoriesPartial()
		{
			var values = context.Categories.Where(x=>x.Status == true).Take(4).ToList();
			return PartialView(values);
		}
		public PartialViewResult CoursesPartial()
		{
			var courses = context.Courses.OrderByDescending(x => x.CourseID).Take(6).ToList();
			var courseAverages = new Dictionary<int, int>(); // Ortalama skoru 'int' türünde saklamak için değiştirdik

			foreach (var course in courses)
			{
				double averageScore = CalculateAverageScore(course.CourseID);
				int roundedAverage = (int)Math.Round(averageScore); // Yuvarlama işlemi

				courseAverages[course.CourseID] = roundedAverage;
			}

			ViewBag.CourseAverages = courseAverages;

			return PartialView(courses);
		}
		public double CalculateAverageScore(int courseId)
		{
			var courseScores = context.CourseScors.Where(cs => cs.CourseID == courseId).ToList();

			if (courseScores.Count == 0)
			{
				return 0.0; // Veya başka bir varsayılan değer
			}

			double totalScore = courseScores.Sum(cs => cs.ScorValue);
			return totalScore / courseScores.Count;
		}
		public PartialViewResult TeamPartial()
		{
			var values = context.Instructors.OrderByDescending(x => x.InstructorID).Take(4).ToList();
			return PartialView(values);
		}
		public PartialViewResult TestimonialPartial()
		{
			var values = context.Testimonials.ToList();
			return PartialView(values);
		}
	}
}