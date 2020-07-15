using Recodme.RD.Lennyouse.Data.RestaurantInfo;
using System;

namespace Recodme.RD.Lennyouse.PresentationLayer.WebAPI.Models.RestaurantInfo
{
    public class TitleViewModel
    {
        public string Position { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public Guid Id { get; set; }        

        public Title ToTitle()
        {
            return new Title( Position, Description, Name);
        }

        public static TitleViewModel Parse(Title title)
        {
            return new TitleViewModel()
            {
                Id = title.Id,
                Name = title.Name,
                Position = title.Position,
                Description = title.Description
            };
        }
        
    }
}
