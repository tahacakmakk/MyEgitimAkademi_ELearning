using MyElearningProject.DAL.Context;
using MyElearningProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyElearningProject.Controllers
{
    public class AboutAdminController : Controller
    {
        ELearningContext context = new ELearningContext();
        [HttpGet]
        public ActionResult Index()
        {
            var values = context.AboutUs.FirstOrDefault();
            return View(values);
        }
        [HttpPost]
        public ActionResult Index(AboutUs aboutUs)
        {
            var values = context.AboutUs.Find(aboutUs.AboutUSID);
            values.ImageUrl = aboutUs.ImageUrl;
            values.Title = aboutUs.Title;   
            values.Description = aboutUs.Description;   
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}