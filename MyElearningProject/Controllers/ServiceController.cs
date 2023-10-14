

using MyElearningProject.DAL.Context;
using MyElearningProject.DAL.Entities;
using System.Linq;
using System.Web.Mvc;

namespace MyElearningProject.Controllers
{
    public class ServiceController : Controller
    {
        ELearningContext context = new ELearningContext();
        public ActionResult Index()
        {
            var values = context.Services.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddService()
        {
            return View();
        }
		[HttpPost]
		public ActionResult AddService(Service service)
		{
            context.Services.Add(service);
            context.SaveChanges();
			return RedirectToAction("Index");

		}
		[HttpGet]
        public ActionResult DeleteService(int id)
        {
            var values =context.Services.Find(id);
            context.Services.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateService(int id)
		{
			var values = context.Services.Find(id);
			return View(values);

		}
		[HttpPost]
		public ActionResult UpdateService(Service service)
		{
			var values = context.Services.Find(service.ServiceID);
            values.Name = service.Name;
            values.Icon = service.Icon;
            values.Description = service.Description;
            context.SaveChanges();
			return RedirectToAction("Index");

		}
	}
}