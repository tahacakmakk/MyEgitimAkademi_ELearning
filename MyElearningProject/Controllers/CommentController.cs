using MyElearningProject.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyElearningProject.Controllers
{
    public class CommentController : Controller
    {
        ELearningContext context = new ELearningContext();  

        public ActionResult Index()
        {
            var values = context.Comments.ToList();
            return View(values);
        }
        public ActionResult ToggleCommentStatus(int id) 
        {
            var values =context.Comments.Find(id);
			if (values != null)
			{
				values.CommentStatus = !values.CommentStatus; // Toggle the IsActive property
				context.SaveChanges();
				return RedirectToAction("Index");
			}
            return View();
		}
    }
}