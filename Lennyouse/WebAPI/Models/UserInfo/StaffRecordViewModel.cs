using Recodme.RD.Lennyouse.Data.UserInfo;
using System;
namespace Recodme.RD.Lennyouse.PresentationLayer.WebAPI.Models.UserInfo

{
    public class StaffRecordViewModel
    {
        public Guid Id { get; set; }     
        public Guid PersonId { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid RestaurantId { get; set; }

        public StaffRecord ToStaffRecord()
        {
            return new StaffRecord(BeginDate, EndDate, PersonId, RestaurantId);
        }

        public static StaffRecordViewModel Parse(StaffRecord staffRecord)
        {
            return new StaffRecordViewModel()
            {
                Id = staffRecord.PersonId,
                BeginDate = staffRecord.BeginDate,
                EndDate = staffRecord.EndDate,
                PersonId = staffRecord.PersonId
            };
        }
    }
}

