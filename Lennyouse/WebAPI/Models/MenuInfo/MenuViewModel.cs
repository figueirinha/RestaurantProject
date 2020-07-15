using Recodme.RD.Lennyouse.Data.MenuInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recodme.RD.Lennyouse.PresentationLayer.WebAPI.Models.MenuInfo
{
    public class MenuViewModel
    {
        public Guid Id { get; set; }        
        public DateTime Date { get; set; }
        public Guid RestaurantId { get; set; }
        public Guid MealId { get; set; }

        public Menu ToMenu()
        {
            return new Menu(Date, RestaurantId, MealId);
        }

        public static MenuViewModel Parse(Menu menu)
        {
            return new MenuViewModel()
            {
                Id = menu.Id,
                Date = menu.Date,
                RestaurantId = menu.RestaurantId,
                MealId = menu.MealId               
            };
        }
    }
}
