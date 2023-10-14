using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyElearningProject.Controllers
{
    public class UILayoutController : Controller
    {
        // GET: UILayout
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult HeadPartial()
        {
            return PartialView();
        }
		public PartialViewResult NavPartial()
		{
			return PartialView();
		}
        public PartialViewResult ScriptPartial()
        {
            return PartialView();
        }
        public PartialViewResult FooterPartial()
        {
            return PartialView();
        }
	}
}