using Recodme.RD.Lennyouse.Data.MenuInfo;
using System;

namespace Recodme.RD.Lennyouse.PresentationLayer.WebAPI.Models.MenuInfo
{
    public class ServingViewModel
    {
        public Guid Id { get; set; }        
        public Guid MenuId { get; set; }
        public Guid CourseId { get; set; }
        public Guid DishId { get; set; }

        public Serving ToServing()
        {
            return new Serving(MenuId, CourseId, DishId);
        }

        public static ServingViewModel Parse(Serving serving)
        {
            return new ServingViewModel()
            {
                Id = serving.Id,
                MenuId = serving.MenuId,
                CourseId = serving.CourseId,
                DishId = serving.DishId
            };
        }
    }
}
