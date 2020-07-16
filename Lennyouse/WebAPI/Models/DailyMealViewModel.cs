using Recodme.RD.Lennyouse.PresentationLayer.WebAPI.Models.MenuInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recodme.RD.Lennyouse.PresentationLayer.WebAPI.Models
{
    public class MenuOfTheDayViewModel
    {
        public MenuViewModel Menu { get; set; }
        public List<MenuOfTheDayMealViewModel> DayMeals { get; set; }
        public MenuOfTheDayViewModel()
        {
            DayMeals = new List<MenuOfTheDayMealViewModel>();
        }
    }
    public class MenuOfTheDayMealViewModel
    {
        public MealViewModel Meal { get; set; }
        public List<MenuOfTheDayCourseViewModel> Courses { get; set; }
        public MenuOfTheDayMealViewModel()
        {
            Courses = new List<MenuOfTheDayCourseViewModel>();
        }
    }
    public class MenuOfTheDayCourseViewModel
    {
        public CourseViewModel Course { get; set; }
        public List<ItemOnMenuOfTheDayViewModel> Items { get; set; }
        public MenuOfTheDayCourseViewModel()
        {
            Items = new List<ItemOnMenuOfTheDayViewModel>();
        }
    }
    public class ItemOnMenuOfTheDayViewModel
    {
        public DishViewModel Dish { get; set; }
        public DietaryRestrictionViewModel DietaryRestriction { get; set; }
    }
}
