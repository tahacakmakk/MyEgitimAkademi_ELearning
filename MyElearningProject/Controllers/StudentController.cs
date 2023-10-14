using MyElearningProject.DAL.Context;
using MyElearningProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyElearningProject.Controllers
{
    public class StudentController : Controller
    {
        ELearningContext context = new ELearningContext();
        public ActionResult Index()
        {
            var values = context.Students.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddStudent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddStudent(Student student)
        {
            context.Students.Add(student);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteStudent(int id)
        {
            var values = context.Students.Find(id);
            context.Students.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateStudent(int id)
        {
            var values = context.Students.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateStudent(Student student)
        {
            var values = context.Students.Find(student.StudentID);
            values.Name = student.Name; 
            values.Surname = student.Surname;
            values.Email = student.Email;
            values.Password = student.Password;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}