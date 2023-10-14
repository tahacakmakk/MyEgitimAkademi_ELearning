using MyElearningProject.DAL.Context;
using MyElearningProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyElearningProject.Controllers
{
    public class CategoryController : Controller
    {
        ELearningContext context = new ELearningContext();
        public ActionResult Index()
        {
            var values = context.Categories.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddCategory() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
           context.Categories.Add(category);
           context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCategory(int id) {
            var values = context.Categories.Find(id);
            context.Categories.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var values = context.Categories.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateCategory(Category c)
        {
            var values = context.Categories.Find(c.CategoryID);
            values.CategoryName = c.CategoryName;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ToggleCategoryStatus(int id)
        {
            var values = context.Categories.Find(id);
			if (values != null)
			{
				values.Status = !values.Status; // Toggle the IsActive property
				context.SaveChanges();
				return RedirectToAction("Index");
			}

			return RedirectToAction("Index");

		}
    }
}