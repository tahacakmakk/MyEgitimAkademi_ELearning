using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyElearningProject.Models
{
	public class CourseViewModel
	{
		public List<MyElearningProject.DAL.Entities.Course> Courses { get; set; }
		public List<MyElearningProject.DAL.Entities.CourseScor> CourseScors { get; set; }
	}
}