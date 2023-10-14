using MyElearningProject.DAL.Context;
using MyElearningProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyElearningProject.Controllers
{
    public class CarouselController : Controller
    {
        ELearningContext context= new ELearningContext();

        public ActionResult Index()
        {
            var values = context.Carousels.ToList();
            return View(values);
        }

        public ActionResult DeleteCarousel(int id) 
        {
            var values = context.Carousels.Find(id);
            context.Carousels.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
		[HttpGet]
		public ActionResult AddCarousel()
		{
			return View();
		}

		[HttpPost]
		public ActionResult AddCarousel(Carousel carousel)
		{
			context.Carousels.Add(carousel);
			context.SaveChanges();
			return RedirectToAction("Index");
		}	

		[HttpGet]
		public ActionResult UpdateCarousel(int id)
		{
			var values = context.Carousels.Find(id);
			return View(values);	
		}

		[HttpPost]
		public ActionResult UpdateCarousel(Carousel carousel)
		{
			var values = context.Carousels.Find(carousel.CarouselID);
            values.Title = carousel.Title;
            values.Title2 = carousel.Title2;
            values.Description = carousel.Description;
            values.ImageUrl = carousel.ImageUrl;
			context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}