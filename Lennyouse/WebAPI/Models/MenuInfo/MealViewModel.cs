﻿using Recodme.RD.Lennyouse.Data.MenuInfo;
using System;

namespace Recodme.RD.Lennyouse.PresentationLayer.WebAPI.Models.MenuInfo
{
    public class MealViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string StartingHours { get; set; }
        public string EndingHours { get; set; }

        public Meal ToMeal()
        {
            return new Meal(Name, StartingHours, EndingHours);
        }
        public static MealViewModel Parse(Meal meal)
        {
            return new MealViewModel()
            {
                Id = meal.Id,
                Name = meal.Name,
                StartingHours = meal.StartingHours,
                EndingHours = meal.EndingHours
            };
        }
    }
}
