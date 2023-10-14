using MyElearningProject.DAL.Context;
using MyElearningProject.DAL.Entities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyElearningProject.Controllers
{
	public class CourseController : Controller
	{
		// GET: Course
		ELearningContext context = new ELearningContext();
		public ActionResult Index()
		{
			var values = context.Courses.ToList();
			return View(values);
		}
		[HttpGet]
		public ActionResult CreateCourese()
		{
			List<SelectListItem> categories = (from x in context.Categories.ToList()
											   select new SelectListItem
											   {
												   Text = x.CategoryName,
												   Value = x.CategoryID.ToString()
											   }).ToList();
			ViewBag.v = categories;

			List<SelectListItem> instructors = (from y in context.Instructors.ToList().OrderBy(x => x.Name)
												select new SelectListItem
												{
													Text = y.Name + " " + y.Surname,
													Value = y.InstructorID.ToString()
												}).ToList();
			ViewBag.v2 = instructors;
			return View();
		}
		[HttpPost]
		public ActionResult CreateCourese(Course course)
		{
			context.Courses.Add(course);
			context.SaveChanges();
			return RedirectToAction("Index");
		}
		public ActionResult DeleteCourse(int id)
		{
			var values = context.Courses.Find(id);
			context.Courses.Remove(values);
			context.SaveChanges();
			return RedirectToAction("Index");

		}
		[HttpGet]
		public ActionResult UpdateCourse(int id)
		{
			List<SelectListItem> categories = (from x in context.Categories.ToList()
											   select new SelectListItem
											   {
												   Text = x.CategoryName,
												   Value = x.CategoryID.ToString()
											   }).ToList();
			ViewBag.v = categories;

			List<SelectListItem> instructors = (from y in context.Instructors.ToList().OrderBy(x => x.Name)
												select new SelectListItem
												{
													Text = y.Name + " " + y.Surname,
													Value = y.InstructorID.ToString()
												}).ToList();
			ViewBag.v2 = instructors;
			var value = context.Courses.Find(id);
			return View(value);
		}
		[HttpPost]
		public ActionResult UpdateCourse(Course course)
		{
			var value = context.Courses.Find(course.CourseID);
			value.Title = course.Title;
			value.InstructorID = course.InstructorID;
			value.Duration = course.Duration;
			value.CourseID = course.CourseID;
			value.ImageUrl = course.ImageUrl;
			value.Price = course.Price;

			context.SaveChanges();
			return RedirectToAction("Index");

		}

		public PartialViewResult Scor()
		{
			var values = context.CourseScors.ToList();
			return PartialView(values);

		}

		[HttpGet]
		public ActionResult AddScor(int id)
		{
			var values = context.CourseScors.ToList();
			ViewBag.Ids = id;
			return View(values);

		}
		[HttpPost]
		public ActionResult AddScor(CourseScor scor)
		{
			var values = context.CourseScors.Find(scor.CourseScorID);
			scor.StudentID = 8;
			context.CourseScors.Add(scor);
			context.SaveChanges();
			return RedirectToAction("Index", "Course");
		}

	}
}