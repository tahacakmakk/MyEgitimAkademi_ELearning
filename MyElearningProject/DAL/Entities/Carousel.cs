using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyElearningProject.DAL.Entities
{
	public class Carousel
	{
        public int CarouselID { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Title2 { get; set; }
        public string Description { get; set; }
    }
}