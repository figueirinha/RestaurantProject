using Recodme.RD.Lennyouse.Data.RestaurantInfo;
using System;
namespace Recodme.RD.Lennyouse.PresentationLayer.WebAPI.Models.RestaurantInfo
{
    public class StaffTitleViewModel
    {
        public Guid StaffRecordId { get; set; }
        public Guid TitleId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid Id { get; set; }


        public StaffTitle ToStaffTitle()
        {
            return new StaffTitle(StaffRecordId, TitleId, StartDate, EndDate);
        }
        public static StaffTitleViewModel Parse(StaffTitle staffTitle)
        {
            return new StaffTitleViewModel()
            {
                StaffRecordId = staffTitle.StaffRecordId,
                TitleId = staffTitle.TitleId,
                StartDate = staffTitle.StartDate,
                EndDate = staffTitle.EndDate,
                Id = staffTitle.Id
            };
        }
    }
}
