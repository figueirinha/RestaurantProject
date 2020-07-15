using Recodme.RD.Lennyouse.Data.RestaurantInfo;
using Recodme.RD.Lennyouse.DataLayer.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Recodme.RD.Lennyouse.Data.MenuInfo
{
    public class Menu : Entity
    {
        private DateTime _date;

        [Required]

        public DateTime Date
        {
            get
            {
                return _date;
            }
            set
            {
                _date = value;
                RegisterChange();
            }
        }

        public virtual ICollection<Serving> Servings { get; set; }
        
        [ForeignKey("Restaurant")]
        public Guid RestaurantId { get; set; }

        [ForeignKey("Meal")]
        public Guid MealId { get; set; }

        public virtual Restaurant Restaurant { get; set; }
        public virtual Meal Meal { get; set; }

        public Menu(DateTime date, Guid restaurantId, Guid mealId) : base()
        {
            _date = date;
            RestaurantId = restaurantId;
            MealId = mealId;
        }
        public Menu(Guid id, DateTime createdAt, DateTime updatedAt, bool isDeleted, DateTime date, Guid restaurantId, Guid mealId)
            : base( id,  createdAt,  updatedAt,  isDeleted)
        {
            _date = date;
            RestaurantId = restaurantId;
            MealId = mealId;
        }
    }
}
