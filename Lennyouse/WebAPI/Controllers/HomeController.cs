using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Recodme.RD.Lennyouse.BusinessLayer.BusinessObjects.MenuInfo;
using Recodme.RD.Lennyouse.Data.MenuInfo;
using Recodme.RD.Lennyouse.PresentationLayer.WebAPI.Models;
using Recodme.RD.Lennyouse.PresentationLayer.WebAPI.Models.MenuInfo;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MenuBusinessObject _menubo = new MenuBusinessObject();
        private MealBusinessObject _mealbo = new MealBusinessObject();
        private CourseBusinessObject _cbo = new CourseBusinessObject();
        private DietaryRestrictionBusinessObject _drbo = new DietaryRestrictionBusinessObject();
        private DishBusinessObject _dbo = new DishBusinessObject();
        private ServingBusinessObject _sbo = new ServingBusinessObject();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var menuOfTheDay = new MenuOfTheDayViewModel();

            var menuListOperation = await _menubo.ListAsync();
            if (!menuListOperation.Success) return View("Error");
            if (menuListOperation.Result.Count == 0) return View("Error");

            var servingListOperation = await _sbo.ListAsync();
            if (!servingListOperation.Success) return View("Error");
            if (servingListOperation.Result.Count == 0) return View("Error");

            var dishListOperation = await _dbo.ListAsync();
            if (!dishListOperation.Success) return View("Error");
            if (dishListOperation.Result.Count == 0) return View("Error");

            var dietaryRestrictionListOperation = await _drbo.ListAsync();
            if (!dietaryRestrictionListOperation.Success) return View("Error");
            if (dietaryRestrictionListOperation.Result.Count == 0) return View("Error");

            var mealListOperation = await _mealbo.ListAsync();
            if (!mealListOperation.Success) return View("Error");
            if (mealListOperation.Result.Count == 0) return View("Error");

            var courseListOperation = await _cbo.ListAsync();
            if (!courseListOperation.Success) return View("Error");
            if (courseListOperation.Result.Count == 0) return View("Error");


            foreach(var serving in servingListOperation.Result)
            {
                var course = courseListOperation.Result.First(x => x.Id == serving.CourseId);
                var dish = dishListOperation.Result.First(x => x.Id == serving.DishId);
                var menu = menuListOperation.Result.First(x => x.Id == serving.MenuId);
                var dr = dietaryRestrictionListOperation.Result.First(x => x.Id == dish.DietaryRestrictionId);
                var meal = mealListOperation.Result.First(x => x.Id == menu.MealId);

                if (meal.Menus == null) meal.Menus = new List<Menu>();
                meal.Menus.Add(menu);
                menu.Meal = meal;

                if (menu.Servings == null) menu.Servings = new List<Serving>();
                menu.Servings.Add(serving);
                serving.Menu = menu;

                if (dr.Dishes == null) dr.Dishes = new List<Dish>();
                dr.Dishes.Add(dish);
                dish.DietaryRestriction = dr;

                if (dish.Servings == null) dish.Servings = new List<Serving>();
                dish.Servings.Add(serving);
                serving.Dish = dish;

                if (course.Servings == null) course.Servings = new List<Serving>();
                course.Servings.Add(serving);
                serving.Course = course;
            }

            List<ItemOnMenuOfTheDayViewModel> items = new List<ItemOnMenuOfTheDayViewModel>();

            foreach(var dr in dietaryRestrictionListOperation.Result)
            {
                var drvm = DietaryRestrictionViewModel.Parse(dr);
                foreach(var dish in dr.Dishes)
                {
                    var dishvm = DishViewModel.Parse(dish);
                    items.Add(new ItemOnMenuOfTheDayViewModel() { DietaryRestriction = drvm, Dish = dishvm });
                }
            }

            return View(menuOfTheDay);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
