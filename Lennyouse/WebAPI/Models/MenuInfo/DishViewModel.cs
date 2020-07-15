using Recodme.RD.Lennyouse.Data.MenuInfo;
using System;

namespace Recodme.RD.Lennyouse.PresentationLayer.WebAPI.Models.MenuInfo
{
    public class DishViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid DietaryRestrictionId { get; set; }

        public Dish ToDish()
        {
            return new Dish(Name, DietaryRestrictionId);
        }

        public static DishViewModel Parse(Dish dish)
        {
            return new DishViewModel()
            {
                Id = dish.Id,
                Name = dish.Name,
                DietaryRestrictionId = dish.DietaryRestrictionId
            };
        }
    }
}
