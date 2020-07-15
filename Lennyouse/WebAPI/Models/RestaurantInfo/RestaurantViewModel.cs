using Recodme.RD.Lennyouse.Data.RestaurantInfo;
using System;

namespace Recodme.RD.Lennyouse.PresentationLayer.WebAPI.Models.RestaurantInfo
{
    public class RestaurantViewModel
    {
        public string Address { get; set; }
        public string OpenningHours { get; set; }
        public string ClosingDays { get; set; }
        public string ClosingHours { get; set; }
        public int TableCount {get; set; }
        public string Name { get; set; }
        public Guid Id { get; set; }

        public Restaurant ToRestaurant()
        {
            return new Restaurant(Name, Address, OpenningHours, ClosingHours, ClosingDays, TableCount);
        }

        public static RestaurantViewModel Parse(Restaurant restaurant)
        {
            return new RestaurantViewModel()
            {
                Address = restaurant.Address,
                OpenningHours = restaurant.OpenningHours,
                ClosingHours = restaurant.ClosingHours,
                ClosingDays = restaurant.ClosingDays,
                TableCount = restaurant.TableCount,
                Id = restaurant.Id,
                Name = restaurant.Name,
            };
        }
    }
}
