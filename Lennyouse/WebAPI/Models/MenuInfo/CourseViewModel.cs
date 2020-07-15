using Recodme.RD.Lennyouse.Data.MenuInfo;
using System;

namespace Recodme.RD.Lennyouse.PresentationLayer.WebAPI.Models.MenuInfo
{
    public class CourseViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Course ToCourse()
        {
            return new Course(Name);
        }

        public static CourseViewModel Parse(Course course)
        {
            return new CourseViewModel()
            {
                Id = course.Id,
                Name = course.Name
            };
        }
    }
}
