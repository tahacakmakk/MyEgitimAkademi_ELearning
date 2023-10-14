using MyElearningProject.DAL.Context;
using MyElearningProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyElearningProject.Controllers
{
    public class InstructorAnalysisController : Controller
    {
        ELearningContext context = new ELearningContext();
        // GET: InstructorAnalysis
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult InstructorPanelPartial()
        {
            int id = 7;
            var values = context.Instructors.Where(x => x.InstructorID == id).ToList();
            var v1 = context.Instructors.Where(x => x.Name == "Ahmet" && x.Surname == "Ölçen").Select(y => y.InstructorID).FirstOrDefault();

            var v2 = context.Courses.Where(x => x.InstructorID == v1).Select(y => y.CourseID).ToList();

            ViewBag.courseCount = context.Courses.Where(x => x.InstructorID == 7).Count();

            return PartialView(values);   
        }

        public PartialViewResult CommentPartial()
        {
            var v1 = context.Instructors.Where(x=>x.Name =="Ahmet" && x.Surname=="Ölçen").Select(y=>y.InstructorID).FirstOrDefault();

            var v2 = context.Courses.Where(x => x.InstructorID == v1).Select(y=>y.CourseID).ToList();

            var v3 = context.Comments.Where(x => v2.Contains(x.CourseID)).ToList();


            return PartialView(v3);
        }

        public PartialViewResult CourseListByInstructor()
        {
            var values = context.Courses.Where(x=>x.InstructorID == 7).ToList();
            var courseDurations = values.Select(x => ConvertToHoursAndMinutes(x.Duration)).ToList();
            ViewBag.v = courseDurations;

            return PartialView(values);
        }

        public PartialViewResult ProfilePane()
        {
            return PartialView();
        }
        public string ConvertToHoursAndMinutes(int dakika)
        {
            int saat = dakika / 60;
            int kalanDakika = dakika % 60;

            if (saat > 0)
            {
                if (kalanDakika > 0)
                {
                    return $"{saat} saat {kalanDakika} dakika";
                }
                else
                {
                    return $"{saat} saat";
                }
            }
            else
            {
                return $"{kalanDakika} dakika";
            }
        }
    }
}